using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository
{
    /// <summary>
    ///     Checks if an email is unique within the user repository.
    /// </summary>
    /// <param name="email">The email to check for uniqueness.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether the
    ///     email is unique.
    /// </returns>
    private async Task<bool> IsEmailUniqueAsync(string? email)
    {
        if (email is null)
            return true;

        var emailExists = await context.Users.AnyAsync(u => u.Email == email);
        return !emailExists;
    }

    /// <summary>
    ///     Checks if a username is unique within the user repository.
    /// </summary>
    /// <param name="userName">The username to check for uniqueness.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether the
    ///     username is unique.
    /// </returns>
    private async Task<bool> IsUserNameUniqueAsync(string? userName)
    {
        if (userName is null)
            return true;

        var userNameExists = await context.Users.AnyAsync(u => u.UserName == userName);

        return !userNameExists;
    }

    /// <summary>
    ///     Determines if another user exists with the same email, excluding the user with the specified ID.
    /// </summary>
    /// <param name="userId">The ID of the user to exclude from the check.</param>
    /// <param name="email">The email to check against other users.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether
    ///     another user exists with the same email.
    /// </returns>
    private async Task<bool> AnotherUserExistsWithSameEmailAsync(Guid userId, string? email)
    {
        if (email is null)
            return false;

        var user = await GetByEmailAsync(email);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
    }

    /// <summary>
    ///     Determines if another user exists with the same username, excluding the user with the specified ID.
    /// </summary>
    /// <param name="userId">The ID of the user to exclude from the check.</param>
    /// <param name="userName">The username to check against other users.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether
    ///     another user exists with the same username.
    /// </returns>
    private async Task<bool> AnotherUserExistsWithSameUserNameAsync(Guid userId, string? userName)
    {
        if (userName is null)
            return false;

        var user = await GetByUserNameAsync(userName);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
    }
}