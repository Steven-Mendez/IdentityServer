using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Users.Exceptions;

public class UserNotFoundException(string propertyName, object attemptedValue) : ValidationException(_errorMessage, BuildErrors(propertyName, attemptedValue))
{
    private static readonly string _errorMessage = "Domain Exception: UserNotFoundException.";

    private static IEnumerable<ValidationFailure> BuildErrors(string propertyName, object attemptedValue) =>
    [
        new(propertyName, $"User with {propertyName} '{attemptedValue}' not found.", attemptedValue)
    ];
}
