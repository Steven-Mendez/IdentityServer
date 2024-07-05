using System.Net;
using System.Text.Json;
using FluentValidation;
using IdentityServer.Presentation.Middlewares.GlobalError.ExtensionMethods;
using IdentityServer.Presentation.Responses;

namespace IdentityServer.Presentation.Middlewares.GlobalError;

/// <summary>
/// Middleware for handling global errors across the application.
/// This class provides a centralized error handling mechanism, catching exceptions thrown from downstream middleware
/// and converting them into appropriate HTTP responses.
/// </summary>
/// <param name="next">The next middleware in the pipeline.</param>
public class GlobalErrorMiddleware(RequestDelegate next)
{
    /// <summary>
    /// Invokes the middleware.
    /// This method tries to execute the next middleware and catches any exceptions thrown,
    /// converting them into structured HTTP responses.
    /// </summary>
    /// <param name="context">The HttpContext for the current request.</param>
    /// <returns>A Task representing the asynchronous operation of this middleware.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            // Proceed with executing the next middleware in the pipeline
            await next(context);
        }
        catch (ValidationException exception)
        {
            // Handle validation exceptions specifically with a 400 Bad Request response
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, exception.ToProblemDetails());
        }
        catch (Exception exception)
        {
            // Handle any other exceptions with a 500 Internal Server Error response
            var response = ApiResponse.CreateError(exception);
            await WriteErrorResponse(context, HttpStatusCode.InternalServerError, response);
        }
    }
    
    /// <summary>
    /// Writes an error response to the HttpContext.
    /// </summary>
    /// <param name="context">The HttpContext to write the error response to.</param>
    /// <param name="statusCode">The HTTP status code to set for the error response.</param>
    /// <param name="error">The error object to serialize into the response body.</param>
    /// <returns>A Task representing the asynchronous operation of writing the error response.</returns>
    private static async Task WriteErrorResponse(HttpContext context, HttpStatusCode statusCode, object error)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }
}