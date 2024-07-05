using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a page size value is required but not provided.
/// Inherits from <see cref="ValidationException"/> to provide detailed validation errors.
/// </summary>
public class PageSizeMustHaveValueException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    /// The error message that is associated with this exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageSizeMustHaveValueException.";

    /// <summary>
    /// Builds the validation errors for the exception, indicating that a page size value is required.
    /// This method constructs a list of <see cref="ValidationFailure"/> objects that detail the nature of the validation error.
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