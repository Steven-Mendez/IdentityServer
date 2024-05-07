using IdentityServer.Domain.Helpers;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Users.Repositories;

public class UserRepository(IdentityServerContext context, IPasswordHasher passwordHasher) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await context.Users
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync();
        return users;
    }

    public async Task<(IEnumerable<User> Users, int TotalRecords)> GetByCriteriaAsync(
        List<ICriteria<User>> criteriaList, ISorter sorting, IPagination pagination)
    {
        var userQuery = context.Users
            .AsNoTracking()
            .AsSplitQuery()
            .ApplyCriteria(criteriaList)
            .ApplySorting(sorting)
            .ApplyPagination(pagination);

        var users = await userQuery.ToListAsync();

        var totalRecords = await context.Users
            .ApplyCriteria(criteriaList)
            .CountAsync();

        return (users, totalRecords);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await context.Users.FindAsync(id);

        var userNotExists = user is null;

        if (userNotExists)
            throw new UserNotFoundException(nameof(id), id);

        return user!;
    }

    public async Task<User> AddAsync(User entity)
    {
        var isEmailUnique = await IsEmailUniqueAsync(entity.Email);

        if (!isEmailUnique)
            throw new EmailAlreadyExistsException(entity.Email);

        var isUserNameUnique = await IsUserNameUniqueAsync(entity.UserName);

        if (!isUserNameUnique)
            throw new UserNameAlreadyExistsException(entity.UserName);

        entity.Password = passwordHasher.Hash(entity.Password);

        var entityEntry = await context.Users.AddAsync(entity);
        var addedUser = entityEntry.Entity;
        return addedUser;
    }

    public async Task UpdateAsync(Guid id, User entity)
    {
        var anotherUserExistsWithSameEmail = await AnotherUserExistsWithSameEmailAsync(id, entity.Email);

        if (anotherUserExistsWithSameEmail)
            throw new EmailAlreadyExistsException(entity.Email);

        var anotherUserExistsWithSameUserName = await AnotherUserExistsWithSameUserNameAsync(id, entity.UserName);

        if (anotherUserExistsWithSameUserName)
            throw new UserNameAlreadyExistsException(entity.UserName);

        context.Users.Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await context.Users.FindAsync(id);

        if (userToDelete is null)
            throw new UserNotFoundException(nameof(id), id);

        userToDelete.IsDeleted = true;
    }

    public async Task<User> AuthenticateAsync(string userNameOrEmail, string password)
    {
        var user = await GetByUserNameOrEmailAsync(userNameOrEmail);

        var userNotExists = user is null;
        var propertyName = userNameOrEmail.Contains('@') ? "Email" : "UserName";

        if (userNotExists)
            throw new AuthenticationFailedException(propertyName);

        var passwordNotMatch = !passwordHasher.Verify(password, user!.Password);

        if (passwordNotMatch)
            throw new AuthenticationFailedException(propertyName);

        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user;
    }

    public async Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail)
    {
        var user = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName == userNameOrEmail || u.Email == userNameOrEmail);
        return user;
    }

    public async Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        var activeUsers = await context.Users.Where(u => !u.IsBlocked).ToListAsync();
        return activeUsers;
    }

    public async Task<IEnumerable<User>> GetBlockedUsersAsync()
    {
        var blockedUsers = await context.Users.Where(u => u.IsBlocked).ToListAsync();
        return blockedUsers;
    }

    public async Task<bool> UserExistsAsync(string userNameOrEmail)
    {
        var user = await GetByUserNameOrEmailAsync(userNameOrEmail);

        var userExists = user is not null;

        return userExists;
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var emailExists = await context.Users.AnyAsync(u => u.Email == email);
        return !emailExists;
    }

    public async Task<bool> IsUserNameUniqueAsync(string userName)
    {
        var userNameExists = await context.Users.AnyAsync(u => u.UserName == userName);
        return !userNameExists;
    }

    public async Task<bool> AnotherUserExistsWithSameEmailAsync(Guid userId, string email)
    {
        var user = await GetByEmailAsync(email);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
    }

    public async Task<bool> AnotherUserExistsWithSameUserNameAsync(Guid userId, string userName)
    {
        var user = await GetByUserNameAsync(userName);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
    }

    public async Task ToggleBlockStatusAsync(Guid userId, bool blockStatus)
    {
        var user = await GetByIdAsync(userId);
        user.IsBlocked = blockStatus;
    }
}