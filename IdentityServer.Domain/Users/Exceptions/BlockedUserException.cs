using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class BlockedUserException(string username) : ValidationException(_errorMessage, BuildErrors(username))
{
    private static readonly string _errorMessage = "Domain Exception: BlockedUserException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string username) =>
    [
        new(nameof(User.UserName), $"User '{username}' is blocked.")
    ];
}
