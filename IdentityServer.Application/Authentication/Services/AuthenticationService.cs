using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.Authenticate;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Responses;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Application.Authentication.Services;

public class AuthenticationService(AuthenticateUseCase authenticateUseCase, IConfiguration configuration) : IAuthenticationService
{
    private readonly string _clientId = GetValueFromConfiguration(configuration, "AzureAd:ClientId");
    private readonly string _tenantId = GetValueFromConfiguration(configuration, "AzureAd:TenantId");
    private readonly string _redirectUri = GetValueFromConfiguration(configuration, "IdentityServerSettings:Url");
    
    private static string GetValueFromConfiguration(IConfiguration configuration, string key)
    {
        var value = configuration[key];
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(configuration), $"Configuration value for '{key}' is missing or empty.");
        return value;
    }
    
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var result = await authenticateUseCase.ExecuteAsync(request);
        return result;
    }

    public string GetAzureAdUrl()
    {
        return $"https://login.microsoftonline.com/{_tenantId}/oauth2/v2.0/authorize?client_id={_clientId}&redirect_uri={_redirectUri}/api/Authentication/azure-ad&response_type=code&scope=user.read";
    }
}