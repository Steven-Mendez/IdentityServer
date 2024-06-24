using IdentityServer.Domain.Helpers;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository
{
    private IQueryable<User> GetUsersQuery => context.Users
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

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
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

    public async Task<User?> GetByMicrosoftIdAsync(string microsoftId)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.MicrosoftId == microsoftId);
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
}