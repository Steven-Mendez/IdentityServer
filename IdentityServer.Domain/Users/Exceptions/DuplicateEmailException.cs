using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
/// Represents an exception that is thrown when attempting to create a user with a duplicate email.
/// Inherits from <see cref="ValidationException"/>.
/// </summary>
/// <param name="email">The email address that already exists and caused the exception.</param>
public class DuplicateEmailException(string email) : ValidationException(ErrorMessage, BuildErrors(email))
{
    /// <summary>
    /// The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: DuplicateEmailException.";

    /// <summary>
    /// Builds the validation errors for the exception.
    /// </summary>
    /// <param name="email">The email address that already exists.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string email)
    {
        return
        [
            new ValidationFailure(nameof(User.Email), $"User with email '{email}' already exists.", email)
        ];
    }
}