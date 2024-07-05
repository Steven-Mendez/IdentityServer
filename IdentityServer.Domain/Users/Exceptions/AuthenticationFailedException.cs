using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
/// Represents an exception that is thrown when user authentication fails.
/// Inherits from <see cref="ValidationException"/>.
/// </summary>
/// <param name="propertyName">The name of the property that caused the authentication failure.</param>
public class AuthenticationFailedException(string propertyName)
    : ValidationException(ErrorMessage, BuildErrors(propertyName))
{
    /// <summary>
    /// The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: AuthenticationFailedException.";

    /// <summary>
    /// Builds the validation errors for the exception.
    /// </summary>
    /// <param name="propertyName">The name of the property that caused the authentication failure.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName)
    {
        return
        [
            new ValidationFailure(propertyName, $"Authentication failed. Invalid {propertyName} or password.")
        ];
    }
}