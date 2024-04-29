using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

public class PageSizeMustBePositiveException() : ValidationException(ErrorMessage, BuildErrors())
{
    private const string ErrorMessage = "Domain Exception: PageSizeMustBePositiveException.";

    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", "Page size must be positive.")
        ];
    }
}