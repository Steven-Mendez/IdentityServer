using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Users.Repositories;

public partial class UserRepository
{
    private async Task<bool> IsEmailUniqueAsync(string? email)
    {
        if (email is null)
            return true;

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

    private async Task<bool> AnotherUserExistsWithSameEmailAsync(Guid userId, string? email)
    {
        if (email is null)
            return false;

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
}