using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
///     Builds the validation errors associated with this exception.
///     This method specifically constructs a list of <see cref="ValidationFailure" /> objects that detail the nature of
///     the validation error.
///     In this case, it indicates that the page number must be a positive value.
/// </summary>
/// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the validation errors.</returns>
public class PageNumberMustHaveValueException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    ///     The error message that is associated with this exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageNumberMustHaveValueException.";

    /// <summary>
    ///     Builds the validation errors associated with this exception.
    ///     This method specifically constructs a list of <see cref="ValidationFailure" /> objects that detail the nature of
    ///     the validation error.
    ///     In this case, it indicates that the page number must be a positive value.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}" /> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageNumber", "Page number must have a value.")
        ];
    }
}