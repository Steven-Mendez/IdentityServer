using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
///     Represents an exception that is thrown when attempting to create a user with a duplicate username.
///     Inherits from <see cref="ValidationException" />.
/// </summary>
/// <param name="username">The username that already exists and caused the exception.</param>
public class DuplicateUsernameException(string username) : ValidationException(ErrorMessage, BuildErrors(username))
{
    /// <summary>
    ///     The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: DuplicateUsernameException.";

    /// <summary>
    ///     Builds the validation errors for the exception.
    /// </summary>
    /// <param name="username">The username that already exists.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string username)
    {
        return
        [
            new ValidationFailure(nameof(User.UserName), $"User with username '{username}' already exists.", username)
        ];
    }
}