using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository
{
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

    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await context.Users.FindAsync(id);

        if (userToDelete is null)
            throw new UserNotFoundException(nameof(id), id);

        userToDelete.IsDeleted = true;
    }
}