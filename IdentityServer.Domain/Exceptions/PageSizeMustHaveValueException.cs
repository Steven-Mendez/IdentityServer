using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

public class PageSizeMustHaveValueException() : ValidationException(ErrorMessage, BuildErrors())
{
    private const string ErrorMessage = "Domain Exception: PageSizeMustHaveValueException.";

    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", $"Page size must have a value.")
        ];
    }
}