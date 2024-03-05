using IdentityServer.Presentation.Responses;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace IdentityServer.Presentation.Middlewares;

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
            var response = ApiResponse.CreateError(exception);
            var json = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(json);
        }
        catch (Exception exception)
        {
            var response = ApiResponse.CreateError(exception);
            var json = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(json);
        }
    }
}
