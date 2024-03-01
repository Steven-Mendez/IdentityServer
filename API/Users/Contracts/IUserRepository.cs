using API.Abstraction;
using API.Users.Models;

namespace API.Users.Contracts;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUserNameAsync(string userName);
    Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail);
    Task<IEnumerable<User>> GetActiveUsersAsync();
    Task<IEnumerable<User>> GetBlockedUsersAsync();
    Task<User> AuthenticateAsync(string userNameOrEmail, string password);
    Task<User> UserExistsAsync(string userNameOrEmail, string password);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsUserNameUniqueAsync(string userName);
    Task<IEnumerable<User>> SearchUsersAsync(string searchTerm);
    Task<bool> ToggleBlockStatusAsync(int userId, bool blockStatus);
}
