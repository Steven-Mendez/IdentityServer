using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class DuplicateEmailException(string email) : ValidationException(ErrorMessage, BuildErrors(email))
{
    private const string ErrorMessage = "Domain Exception: DuplicateEmailException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string email)
    {
        return
        [
            new ValidationFailure(nameof(User.Email), $"User with email '{email}' already exists.", email)
        ];
    }
}