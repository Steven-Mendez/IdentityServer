using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

public class UserNotFoundException(string propertyName, object attemptedValue)
    : ValidationException(ErrorMessage, BuildErrors(propertyName, attemptedValue))
{
    private const string ErrorMessage = "Domain Exception: UserNotFoundException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName, object attemptedValue)
    {
        return
        [
            new ValidationFailure(propertyName, $"User with {propertyName} '{attemptedValue}' not found.",
                attemptedValue)
        ];
    }
}