using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Domain.Exceptions;

public class PageNumberMustHaveValueException() : ValidationException(ErrorMessage, BuildErrors())
{
    private const string ErrorMessage = "Domain Exception: PageNumberMustHaveValueException.";

    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageNumber", $"Page number must have a value.")
        ];
    }
}