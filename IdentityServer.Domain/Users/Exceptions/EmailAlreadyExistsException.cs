using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public class EmailAlreadyExistsException(string email) : ValidationException(ErrorMessage, BuildErrors(email))
{
    private const string ErrorMessage = "Domain Exception: EmailAlreadyExistsException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string email)
    {
        return
        [
            new ValidationFailure(nameof(User.Email), $"Email '{email}' already exists.", email)
        ];
    }
}