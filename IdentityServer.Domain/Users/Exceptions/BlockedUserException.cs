using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
///     Represents an exception that is thrown when an operation is attempted on a blocked user.
///     Inherits from <see cref="ValidationException" />.
/// </summary>
/// <param name="username">The username of the blocked user.</param>
public class BlockedUserException(string username) : ValidationException(ErrorMessage, BuildErrors(username))
{
    /// <summary>
    ///     The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: BlockedUserException.";

    /// <summary>
    ///     Builds the validation errors for the exception.
    /// </summary>
    /// <param name="username">The username of the blocked user.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string username)
    {
        return
        [
            new ValidationFailure(nameof(User.UserName), $"User '{username}' is blocked.")
        ];
    }
}