using IdentityServer.Domain.Helpers;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository
{
    /// <summary>
    ///     Gets a queryable collection of all users with no tracking and split query optimization.
    /// </summary>
    private IQueryable<User> GetUsersQuery => context.Users
        .AsNoTracking()
        .AsSplitQuery();

    /// <summary>
    ///     Retrieves all users ordered by first name and then by last name.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of users.</returns>
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await GetUsersQuery
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync();
        return users;
    }

    /// <summary>
    ///     Retrieves users based on specified criteria, including filtering, sorting, and pagination.
    /// </summary>
    /// <param name="specification">The criteria to apply.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a tuple of user items and total
    ///     record count.
    /// </returns>
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

    /// <summary>
    ///     Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user entity.</returns>
    /// <exception cref="UserNotFoundException">Thrown when a user with the specified ID does not exist.</exception>
    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await context.Users.FindAsync(id);

        var userNotExists = user is null;

        if (userNotExists)
            throw new UserNotFoundException(nameof(id), id);

        return user!;
    }

    /// <summary>
    ///     Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the user entity or null if not
    ///     found.
    /// </returns>
    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    /// <summary>
    ///     Authenticates a user based on their username or email and password.
    /// </summary>
    /// <param name="userNameOrEmail">The username or email of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authenticated user entity.</returns>
    /// <exception cref="AuthenticationFailedException">
    ///     Thrown when authentication fails due to non-existent user or incorrect
    ///     password.
    /// </exception>
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

    /// <summary>
    ///     Retrieves a user by their Microsoft ID.
    /// </summary>
    /// <param name="microsoftId">The Microsoft ID of the user.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the user entity or null if not
    ///     found.
    /// </returns>
    public async Task<User?> GetByMicrosoftIdAsync(string microsoftId)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.MicrosoftId == microsoftId);
        return user;
    }

    /// <summary>
    ///     Retrieves a user by their username.
    /// </summary>
    /// <param name="userName">The username of the user.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the user entity or null if not
    ///     found.
    /// </returns>
    private async Task<User?> GetByUserNameAsync(string userName)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user;
    }

    /// <summary>
    ///     Retrieves a user by either their username or email.
    /// </summary>
    /// <param name="userNameOrEmail">The username or email of the user.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the user entity or null if not
    ///     found.
    /// </returns>
    private async Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail)
    {
        var user = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName == userNameOrEmail || u.Email == userNameOrEmail);
        return user;
    }
}