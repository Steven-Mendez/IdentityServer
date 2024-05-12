using IdentityServer.Application.Authentication.Helpers;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

public class AzureAdAuthenticationRedirectUseCase(IConfiguration configuration)
{
    private const string BaseUrl = "https://login.microsoftonline.com/";
    private const string AuthorizeEndpoint = "/oauth2/v2.0/authorize";
    private const string ResponseTypeParam = "response_type=code";
    private const string ScopeParam = "scope=user.read";
    private const string OptionsUrl = $"&{ResponseTypeParam}&{ScopeParam}";
    private readonly string _clientId = ConfigurationHelper.GetValueFromConfiguration(configuration, "AzureAd:ClientId");
    private readonly string _redirectUrl = ConfigurationHelper.GetValueFromConfiguration(configuration, "IdentityServerSettings:Url");
    private readonly string _tenantId = ConfigurationHelper.GetValueFromConfiguration(configuration, "AzureAd:TenantId");
    
    public string Execute()
    {
        var clientIdParam = $"client_id={_clientId}";
        var redirectUriParam = $"redirect_uri={_redirectUrl}/api/Authentication/Oauth2.0/azure-ad/callback";
        var mainUrl = $"{BaseUrl}{_tenantId}{AuthorizeEndpoint}?";
        var paramsUrl = $"{clientIdParam}&{redirectUriParam}";
        
        var url = $"{mainUrl}{paramsUrl}{OptionsUrl}";
        return url;
    }
}