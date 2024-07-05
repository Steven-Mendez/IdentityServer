using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a user is not found based on a specific property value.
/// Inherits from <see cref="ValidationException"/>.
/// </summary>
/// <param name="propertyName">The name of the property based on which the user was not found.</param>
/// <param name="attemptedValue">The value attempted to find the user.</param>
public class UserNotFoundException(string propertyName, object attemptedValue)
    : ValidationException(ErrorMessage, BuildErrors(propertyName, attemptedValue))
{
    /// <summary>
    /// The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: UserNotFoundException.";

    /// <summary>
    /// Builds the validation errors for the exception.
    /// </summary>
    /// <param name="propertyName">The name of the property based on which the user was not found.</param>
    /// <param name="attemptedValue">The value attempted to find the user.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName, object attemptedValue)
    {
        return
        [
            new ValidationFailure(propertyName, $"User with {propertyName} '{attemptedValue}' not found.",
                attemptedValue)
        ];
    }
}