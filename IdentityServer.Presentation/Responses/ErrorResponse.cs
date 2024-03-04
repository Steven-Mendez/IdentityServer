using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Presentation.Responses;

public class ErrorResponse(Exception exception)
{
    public string ErrorMessage { get; } = exception.Message;
    public string ErrorType { get; } = exception.GetType().Name;
    public string ErrorDetails { get; } = GetErrorDetails(exception);
    public string StackTrace { get; } = @$"{exception.StackTrace!}";

    private static string GetErrorDetails(Exception exception)
    {
        if (exception is ValidationException validationException)
        {
            return validationException.ValidationResult.ErrorMessage!;
        }

        return exception.Message;
    }
}
