using ApdAPI.Models;
using ApdAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace ApdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Método GET
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var createdUser = await _userService.RegisterUserAsync(user);
            return Ok(createdUser.Email);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var passwordHash = GetSHA256(loginRequest.Password);
            var user = await _userService.AuthenticateUserAsync(loginRequest.Email, passwordHash);
            if (user == null)
            {
                return Unauthorized();
            }

            var (accessToken, refreshToken) = await _userService.GenerateTokensAsync(user);

            return Ok(new
            {
                UserId = user.Id, // Asumiendo que tienes un campo Id en tu entidad User
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }




        private string GetSHA256(string str)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.AppendFormat("{0:x2}", b);
            }
            return builder.ToString();
        }

        [HttpOptions]
        public IActionResult Options()
        {
            // Utiliza la política CORS definida en tu program.cs
            Response.Headers.Add("Access-Control-Allow-Origin", "_myAllowSpecificOrigins");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

            // Devuelve una respuesta 200 OK para indicar que la solicitud OPTIONS fue exitosa
            return Ok();
        }


    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
