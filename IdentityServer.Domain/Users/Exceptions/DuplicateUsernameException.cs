using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class DuplicateUsernameException(string username) : ValidationException(_errorMessage, BuildErrors(username))
{
    private static readonly string _errorMessage = "Domain Exception: DuplicateUsernameException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string username) =>
    [
        new(nameof(User.UserName), $"User with username '{username}' already exists.", username)
    ];
}
