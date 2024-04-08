using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class DuplicateUsernameException(string username) : ValidationException(ErrorMessage, BuildErrors(username))
{
    private const string ErrorMessage = "Domain Exception: DuplicateUsernameException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string username)
    {
        return
        [
            new ValidationFailure(nameof(User.UserName), $"User with username '{username}' already exists.", username)
        ];
    }
}