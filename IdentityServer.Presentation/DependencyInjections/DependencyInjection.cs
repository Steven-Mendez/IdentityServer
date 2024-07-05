using IdentityServer.Application.Options;

namespace IdentityServer.Presentation.DependencyInjections;

/// <summary>
/// Provides extension methods for IServiceCollection to add settings configurations.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds configuration settings to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the settings to.</param>
    /// <param name="configuration">The IConfiguration containing the settings.</param>
    /// <remarks>
    /// This method configures the services with settings from the appsettings.json file or any other configuration source specified in the application.
    /// The settings are bound to strongly typed objects for easier access throughout the application.
    /// </remarks>
    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureAdSettings>(configuration.GetSection("AzureAdSettings"));
        services.Configure<FrontendSettings>(configuration.GetSection("FrontendSettings"));
        services.Configure<IdentityServerSettings>(configuration.GetSection("IdentityServerSettings"));
        services.Configure<JsonWebTokenSettings>(configuration.GetSection("JsonWebTokenSettings"));
    }
}