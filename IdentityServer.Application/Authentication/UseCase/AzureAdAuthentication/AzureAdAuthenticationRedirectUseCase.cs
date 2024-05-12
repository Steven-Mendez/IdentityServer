using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

public class AzureAdAuthenticationRedirectUseCase(IOptions<AzureAdSettings> azureOptions, IOptions<IdentityServerSettings> identityServerOptions)
{
    private const string BaseUrl = "https://login.microsoftonline.com/";
    private const string AuthorizeEndpoint = "/oauth2/v2.0/authorize";
    private const string ResponseTypeParam = "response_type=code";
    private const string ScopeParam = "scope=user.read";
    private const string OptionsUrl = $"&{ResponseTypeParam}&{ScopeParam}";
    private readonly string _clientId = azureOptions.Value.ClientId;
    private readonly string _redirectUrl = identityServerOptions.Value.Url;
    private readonly string _tenantId = azureOptions.Value.TenantId;
    
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