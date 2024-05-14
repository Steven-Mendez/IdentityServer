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
}