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
    private IQueryable<User> GetUsersQuery => context.Users
        .Include(user => user.UserType)
        .AsNoTracking()
        .AsSplitQuery();

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await GetUsersQuery
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync();
        return users;
    }

    public async Task<(IEnumerable<User> Items, int TotalRecords)> GetByCriteriaAsync(
        ISpecification<User> specification)
    {
        var query = GetUsersQuery
            .ApplyCriteria(specification.Filters);

        var totalRecords = await query.CountAsync();

        var users = await query
            .ApplySorting(specification.SortingOptions)
            .ApplyPagination(specification.PaginationOptionsOptions)
            .ToListAsync();

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
            throw new UserNameAlreadyExistsException(entity.UserName!);

        if (entity.Password is not null)
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

    public async Task<User> AuthenticateAsync(string userNameOrEmail, string password)
    {
        var user = await GetByUserNameOrEmailAsync(userNameOrEmail);

        var userNotExists = user is null;
        var propertyName = userNameOrEmail.Contains('@') ? "Email" : "UserName";

        if (userNotExists)
            throw new AuthenticationFailedException(propertyName);

        var passwordNotMatch = !passwordHasher.Verify(password, user!.Password!);

        if (passwordNotMatch)
            throw new AuthenticationFailedException(propertyName);

        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    private async Task<User?> GetByUserNameAsync(string userName)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user;
    }

    private async Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail)
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

    private async Task<bool> IsEmailUniqueAsync(string email)
    {
        var emailExists = await context.Users.AnyAsync(u => u.Email == email);
        return !emailExists;
    }

    private async Task<bool> IsUserNameUniqueAsync(string? userName)
    {
        if (userName is null)
            return true;

        var userNameExists = await context.Users.AnyAsync(u => u.UserName == userName);

        return !userNameExists;
    }

    private async Task<bool> AnotherUserExistsWithSameEmailAsync(Guid userId, string email)
    {
        var user = await GetByEmailAsync(email);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
    }

    private async Task<bool> AnotherUserExistsWithSameUserNameAsync(Guid userId, string? userName)
    {
        if (userName is null)
            return false;

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