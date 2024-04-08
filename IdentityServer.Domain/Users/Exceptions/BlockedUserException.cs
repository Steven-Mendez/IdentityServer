using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class BlockedUserException(string username) : ValidationException(ErrorMessage, BuildErrors(username))
{
    private const string ErrorMessage = "Domain Exception: BlockedUserException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string username)
    {
        return
        [
            new ValidationFailure(nameof(User.UserName), $"User '{username}' is blocked.")
        ];
    }
}