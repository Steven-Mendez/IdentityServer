using FluentValidation;
using IdentityServer.Presentation.Middlewares.GlobalError.ExtensionMethods;
using IdentityServer.Presentation.Responses;
using System.Net;
using System.Text.Json;

namespace IdentityServer.Presentation.Middlewares.GlobalError;

public class GlobalErrorMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var error = exception.ToProblemDetails();
            await context.Response.WriteAsJsonAsync(error);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = ApiResponse.CreateError(exception);
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
