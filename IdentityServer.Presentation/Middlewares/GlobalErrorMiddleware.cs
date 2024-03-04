using IdentityServer.Presentation.Responses;
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
        catch (Exception exception)
        {
            var response = new ErrorResponse(exception);
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions() { WriteIndented = true });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(json);
        }
    }
}
