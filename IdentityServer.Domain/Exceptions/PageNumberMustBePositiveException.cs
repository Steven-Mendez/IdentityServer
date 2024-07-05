using FluentValidation;
using FluentValidation.Results;

namespace IdentityServer.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a non-positive page number is provided where a positive one is required.
/// This exception specifically extends the <see cref="ValidationException"/> to include detailed validation errors.
/// </summary>
public class PageNumberMustBePositiveException() : ValidationException(ErrorMessage, BuildErrors())
{
    /// <summary>
    /// The error message that is associated with this exception.
    /// </summary>
    private const string ErrorMessage = "Domain Exception: PageNumberMustBePositiveException.";

    /// <summary>
    /// Builds the validation errors associated with this exception.
    /// This method specifically constructs a list of <see cref="ValidationFailure"/> objects that detail the nature of the validation error.
    /// In this case, it indicates that the page number must be a positive value.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{ValidationFailure}"/> representing the validation errors.</returns>
    private static IEnumerable<ValidationFailure> BuildErrors()
    {
        return
        [
            new ValidationFailure("pageSize", "Page number must be positive.")
        ];
    }
}