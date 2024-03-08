using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class DuplicateEmailException(string email) : ValidationException(_errorMessage, BuildErrors(email))
{
    private static readonly string _errorMessage = "Domain Exception: DuplicateEmailException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string email) =>
    [
        new(nameof(User.Email), $"User with email '{email}' already exists.", email)
    ];
}
