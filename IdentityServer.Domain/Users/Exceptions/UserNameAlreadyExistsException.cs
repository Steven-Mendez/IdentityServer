using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public sealed class UserNameAlreadyExistsException(string userName)
    : ValidationException(ErrorMessage, BuildErrors(userName))
{
    private const string ErrorMessage = "Domain Exception: UserNameAlreadyExistsException";

    private static IEnumerable<ValidationFailure> BuildErrors(string userName)
    {
        return
        [
            new ValidationFailure(nameof(User.UserName), $"Username '{userName}' already exists.", userName)
        ];
    }
}