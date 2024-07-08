using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

/// <summary>
///     Represents an exception that is thrown when attempting to create a user with a username that already exists.
///     Inherits from <see cref="ValidationException" />.
/// </summary>
/// <param name="userName">The username that already exists and caused the exception.</param>
public sealed class UserNameAlreadyExistsException(string userName)
    : ValidationException(ErrorMessage, BuildErrors(userName))
{
    /// <summary>
    ///     The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: UserNameAlreadyExistsException";

    /// <summary>
    ///     Builds the validation errors for the exception.
    /// </summary>
    /// <param name="userName">The username that already exists.</param>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors(string userName)
    {
        return
        [
            new ValidationFailure(nameof(User.UserName), $"Username '{userName}' already exists.", userName)
        ];
    }
}