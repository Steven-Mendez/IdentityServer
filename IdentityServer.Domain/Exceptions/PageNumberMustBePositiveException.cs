using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

public class PageNumberMustBePositiveException() : ValidationException(ErrorMessage, BuildErrors())
{
    private const string ErrorMessage = "Domain Exception: PageNumberMustBePositiveException.";

    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", "Page number must be positive.")
        ];
    }
}