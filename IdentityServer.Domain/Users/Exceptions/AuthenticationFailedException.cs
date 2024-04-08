using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

public class AuthenticationFailedException(string propertyName)
    : ValidationException(ErrorMessage, BuildErrors(propertyName))
{
    private const string ErrorMessage = "Domain Exception: AuthenticationFailedException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName)
    {
        return
        [
            new ValidationFailure(propertyName, $"Authentication failed. Invalid {propertyName} or password.")
        ];
    }
}