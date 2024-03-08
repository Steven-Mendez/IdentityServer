using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class EmailAlreadyExistsException(string email) : ValidationException(_errorMessage, BuildErrors(email))
{
    private static readonly string _errorMessage = "Domain Exception: EmailAlreadyExistsException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string email) =>
    [
        new(nameof(User.Email), $"Email '{email}' already exists.", email)
    ];
}