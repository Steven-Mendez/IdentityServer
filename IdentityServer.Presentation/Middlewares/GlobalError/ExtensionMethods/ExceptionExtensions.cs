using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Middlewares.GlobalError.ExtensionMethods;

/// <summary>
///     Provides extension methods for exceptions.
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    ///     Converts a <see cref="ValidationException" /> to a <see cref="ValidationProblemDetails" /> object.
    /// </summary>
    /// <param name="exception">The <see cref="ValidationException" /> instance to convert.</param>
    /// <returns>A <see cref="ValidationProblemDetails" /> object containing the details of the validation errors.</returns>
    /// <remarks>
    ///     This method iterates over the errors in the <see cref="ValidationException" /> and adds them to a
    ///     <see cref="ValidationProblemDetails" /> instance. If multiple errors exist for the same property,
    ///     they are concatenated into a single entry in the <see cref="ValidationProblemDetails.Errors" /> dictionary.
    /// </remarks>
    public static ValidationProblemDetails ToProblemDetails(this ValidationException exception)
    {
        var error = new ValidationProblemDetails
        {
            Type = @"https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Status = StatusCodes.Status400BadRequest
        };

        // Iterate over each validation error in the exception.
        foreach (var validationError in exception.Errors)
        {
            // Check if the error dictionary already contains an entry for the property name.
            if (error.Errors.TryGetValue(validationError.PropertyName, out var value))
            {
                // If so, concatenate the new error message to the existing ones.
                error.Errors[validationError.PropertyName] = value.Concat([validationError.ErrorMessage]).ToArray();
                continue;
            }

            // If not, add a new entry to the dictionary with the property name and error message.
            error.Errors.Add(new KeyValuePair<string, string[]>(validationError.PropertyName,
                [validationError.ErrorMessage]));
        }

        return error;
    }
}