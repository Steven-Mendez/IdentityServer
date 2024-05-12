using Microsoft.Extensions.Configuration;

namespace IdentityServer.Application.Authentication.Helpers;

public static class ConfigurationHelper
{
    public static string GetValueFromConfiguration(IConfiguration configuration, string key)
    {
        var value = configuration[key];
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(configuration),
                $"Configuration value for '{key}' is missing or empty.");
        return value;
    }
}