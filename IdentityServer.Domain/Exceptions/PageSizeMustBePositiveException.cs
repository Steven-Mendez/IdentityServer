using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
///     Represents an exception that is thrown when the page size provided for pagination is not positive.
///     Inherits from <see cref="ValidationException" /> to provide detailed validation errors.
/// </summary>
public class PageSizeMustBePositiveException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    ///     The error message that is associated with this exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageSizeMustBePositiveException.";

    /// <summary>
    ///     Builds validation errors for the exception, indicating that the page size must be positive.
    ///     This method constructs a list of <see cref="ValidationFailure" /> objects that detail the nature of the validation
    ///     error.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", "Page size must be positive.")
        ];
    }
}