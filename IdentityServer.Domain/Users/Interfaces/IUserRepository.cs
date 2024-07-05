using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Interfaces;

/// <summary>
/// Represents a repository interface for managing <see cref="User"/> entities.
/// Inherits from <see cref="IRepository{T}"/>.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Authenticates a user asynchronously using their username or email and password.
    /// </summary>
    /// <param name="userNameOrEmail">The username or email of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the authenticated <see cref="User"/>.</returns>
    Task<User> AuthenticateAsync(string userNameOrEmail, string password);
    
    /// <summary>
    /// Retrieves a user by their email asynchronously.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="User"/> with the specified email, or null if no user is found.</returns>
    Task<User?> GetByEmailAsync(string email);
    
    /// <summary>
    /// Retrieves a user by their Microsoft ID asynchronously.
    /// </summary>
    /// <param name="microsoftId">The Microsoft ID of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="User"/> with the specified Microsoft ID, or null if no user is found.</returns>
    Task<User?> GetByMicrosoftIdAsync(string microsoftId);
}