using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> AuthenticateAsync(string userNameOrEmail, string password);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByMicrosoftIdAsync(string microsoftId);
}