using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

public class AuthenticationFailedException(string propertyName) : ValidationException(_errorMessage, BuildErrors(propertyName))
{
    private static readonly string _errorMessage = "Domain Exception: AuthenticationFailedException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName) =>
    [
        new(propertyName, $"Authentication failed. Invalid {propertyName} or password.")
    ];
}
