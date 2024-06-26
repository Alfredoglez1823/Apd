using ApdAPI.Models;
using ApdAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApdAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Session> _sessionRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IRepository<User> userRepository, IRepository<Session> sessionRepository, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> AuthenticateUserAsync(string email, string passwordHash)
        {
            var user = await _userRepository.GetByConditionAsync(u => u.Email == email);
            if (user == null)
            {
                return null;
            }

            if (user.PasswordHash != passwordHash)
            {
                return null;
            }

            return user;
        }

        public async Task<(string, string)> GenerateTokensAsync(User user)
        {
            var accessToken = GenerateJwtToken(user, DateTime.UtcNow.AddMinutes(30));
            var refreshToken = GenerateJwtToken(user, DateTime.UtcNow.AddDays(30));

            var session = new Session
            {
                UserId = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(30)
            };

            await _sessionRepository.AddAsync(session);
            return (accessToken, refreshToken);
        }

        private string GenerateJwtToken(User user, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["KeyJWT"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public int GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return int.Parse(userIdClaim.Value);
        }


    }
}
