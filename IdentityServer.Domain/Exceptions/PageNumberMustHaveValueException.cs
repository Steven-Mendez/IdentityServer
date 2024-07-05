using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
/// ERepresent an exception that is thrown when a page number value is required but not provided.
/// Inherits from <see cref="ValidationException"/>.
/// </summary>
public class PageNumberMustHaveValueException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    /// The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageNumberMustHaveValueException.";

    /// <summary>
    /// Builds validation errors for the exception, indicating that a page number value must be provided.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageNumber", "Page number must have a value.")
        ];
    }
}