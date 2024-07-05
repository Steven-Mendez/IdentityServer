using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a page size value is required but not provided.
/// Inherits from <see cref="ValidationException"/>.
/// </summary>
public class PageSizeMustHaveValueException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    /// The error message for the exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageSizeMustHaveValueException.";

    /// <summary>
    /// Builds the validation errors for the exception.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", "Page size must have a value.")
        ];
    }
}