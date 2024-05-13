using IdentityServer.Application.Authentication.Services;
using IdentityServer.Application.Options;

namespace IdentityServer.Presentation.DependencyInjections;

public static class DependencyInjection
{
    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureAdSettings>(configuration.GetSection("AzureAdSettings"));
        services.Configure<FrontendSettings>(configuration.GetSection("FrontendSettings"));
        services.Configure<IdentityServerSettings>(configuration.GetSection("IdentityServerSettings"));
        services.Configure<JsonWebTokenSettings>(configuration.GetSection("JsonWebTokenSettings"));
    }

    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<AzureAdService>((_, httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://graph.microsoft.com");
        });
    }
}