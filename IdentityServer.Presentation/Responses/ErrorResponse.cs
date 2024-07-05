using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Presentation.Responses;

/// <summary>
/// Represents an error response that encapsulates details about an exception.
/// </summary>
/// <param name="exception">The exception to encapsulate in the error response.</param>
public class ErrorResponse(Exception exception)
{
    /// <summary>
    /// Gets the message of the exception.
    /// </summary>
    public string ErrorMessage { get; } = exception.Message;
    
    /// <summary>
    /// Gets the type name of the exception.
    /// </summary>
    public string ErrorType { get; } = exception.GetType().Name;
    
    /// <summary>
    /// Gets detailed information about the exception, if available.
    /// </summary>
    public string ErrorDetails { get; } = GetErrorDetails(exception);
    
    /// <summary>
    /// Gets the stack trace of the exception.
    /// </summary>
    public string StackTrace { get; } = $"{exception.StackTrace!}";

    /// <summary>
    /// Retrieves detailed error information from the provided exception.
    /// </summary>
    /// <param name="exception">The exception from which to retrieve details.</param>
    /// <returns>A string containing detailed error information, if available; otherwise, the exception's message.</returns>
    private static string GetErrorDetails(Exception exception)
    {
        if (exception is ValidationException validationException)
            return validationException.ValidationResult.ErrorMessage!;

        return exception.Message;
    }
}