using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository
{
    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="entity">The user entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added user entity.</returns>
    /// <exception cref="EmailAlreadyExistsException">Thrown when the email associated with the user already exists in the repository.</exception>
    /// <exception cref="UserNameAlreadyExistsException">Thrown when the username associated with the user already exists in the repository.</exception>
    public async Task<User> AddAsync(User entity)
    {
        var isEmailUnique = await IsEmailUniqueAsync(entity.Email);

        if (!isEmailUnique)
            throw new EmailAlreadyExistsException(entity.Email!);

        var isUserNameUnique = await IsUserNameUniqueAsync(entity.UserName);

        if (!isUserNameUnique)
            throw new UserNameAlreadyExistsException(entity.UserName!);

        if (entity.Password is not null)
            entity.Password = passwordHasher.Hash(entity.Password);

        var entityEntry = await context.Users.AddAsync(entity);
        var addedUser = entityEntry.Entity;
        return addedUser;
    }
    
    /// <summary>
    /// Updates an existing user in the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the user to update.</param>
    /// <param name="entity">The user entity with updated information.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="EmailAlreadyExistsException">Thrown when another user with the same email exists.</exception>
    /// <exception cref="UserNameAlreadyExistsException">Thrown when another user with the same username exists.</exception>
    public async Task UpdateAsync(Guid id, User entity)
    {
        var anotherUserExistsWithTheSameEmail = await AnotherUserExistsWithSameEmailAsync(id, entity.Email!);

        if (anotherUserExistsWithTheSameEmail)
            throw new EmailAlreadyExistsException(entity.Email!);

        var anotherUserExistsWithTheSameUserName = await AnotherUserExistsWithSameUserNameAsync(id, entity.UserName);

        if (anotherUserExistsWithTheSameUserName)
            throw new UserNameAlreadyExistsException(entity.UserName!);

        context.Users.Update(entity);
    }
    
    /// <summary>
    /// Marks a user as deleted in the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="UserNotFoundException">Thrown when the user with the specified ID does not exist.</exception>
    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await context.Users.FindAsync(id);

        if (userToDelete is null)
            throw new UserNotFoundException(nameof(id), id);

        userToDelete.IsDeleted = true;
    }
}