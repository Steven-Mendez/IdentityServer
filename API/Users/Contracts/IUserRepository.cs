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
    Task<bool> UserExistsAsync(string userNameOrEmail);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsUserNameUniqueAsync(string userName);
    Task ToggleBlockStatusAsync(Guid userId, bool blockStatus);
    Task<User> AuthenticateAsync(string userNameOrEmail, string password);
}
