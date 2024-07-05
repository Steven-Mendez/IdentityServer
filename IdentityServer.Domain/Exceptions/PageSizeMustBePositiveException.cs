using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when the page size provided for pagination is not positive.
/// Inherits from <see cref="ValidationException"/>.
/// </summary>
public class PageSizeMustBePositiveException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    /// The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageSizeMustBePositiveException.";

    /// <summary>
    /// Builds validation errors for the exception, indicating that the page size must be positive.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", "Page size must be positive.")
        ];
    }
}