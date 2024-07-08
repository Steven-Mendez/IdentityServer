using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
///     Represents an exception that is thrown when user authentication fails.
///     This exception is specifically used within the domain to signal authentication process failures,
///     allowing for a more granular control over error handling and response messaging.
///     Inherits from <see cref="ValidationException" /> to leverage the structured error reporting of validation failures.
/// </summary>
/// <param name="propertyName">The name of the property that caused the authentication failure.</param>
public class AuthenticationFailedException(string propertyName)
    : ValidationException(ErrorMessage, BuildErrors(propertyName))
{
    /// <summary>
    ///     The default error message for the exception.
    ///     This message is used to provide a general description of the exception when it is thrown.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: AuthenticationFailedException.";

    /// <summary>
    ///     Builds the validation errors for the exception.
    ///     This method creates a collection of <see cref="ValidationFailure" /> objects that describe the specific
    ///     reason(s) for the authentication failure, which in this case is tied to a particular property (e.g., username or
    ///     password).
    /// </summary>
    /// <param name="propertyName">The name of the property that caused the authentication failure.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName)
    {
        return
        [
            new ValidationFailure(propertyName, $"Authentication failed. Invalid {propertyName} or password.")
        ];
    }
}