using ApdAPI.Models;

namespace ApdAPI.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> AuthenticateUserAsync(string email, string passwordHash);
        Task<(string, string)> GenerateTokensAsync(User user);

        Task<IEnumerable<User>> GetUsers();

        int GetUserId();
    }
}
