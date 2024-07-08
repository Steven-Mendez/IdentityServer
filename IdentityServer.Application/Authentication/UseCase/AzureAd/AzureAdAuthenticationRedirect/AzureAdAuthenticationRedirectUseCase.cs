using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationRedirect;

/// <summary>
///     Handles the construction of the Azure AD authentication redirect URL.
/// </summary>
/// <param name="azureOptions">The configuration options for Azure AD.</param>
public class AzureAdAuthenticationRedirectUseCase(IOptions<AzureAdSettings> azureOptions)
{
    private const string BaseUrl = "https://login.microsoftonline.com/";
    private const string AuthorizeEndpoint = "/oauth2/v2.0/authorize";
    private const string ResponseTypeParam = "response_type=code";
    private const string ScopeParam = "scope=user.read";
    private const string OptionsUrl = $"&{ResponseTypeParam}&{ScopeParam}";
    private readonly string _clientId = azureOptions.Value.ClientId;
    private readonly string _redirectUrl = azureOptions.Value.RedirectUrl;
    private readonly string _tenantId = azureOptions.Value.TenantId;

    /// <summary>
    ///     Constructs and returns the URL to redirect users for Azure AD authentication.
    /// </summary>
    /// <returns>The URL to redirect users to Azure AD for authentication.</returns>
    public string Execute()
    {
        var clientIdParam = $"client_id={_clientId}";
        var redirectUriParam = $"redirect_uri={_redirectUrl}";
        var mainUrl = $"{BaseUrl}{_tenantId}{AuthorizeEndpoint}?";
        var paramsUrl = $"{clientIdParam}&{redirectUriParam}";
        var url = $"{mainUrl}{paramsUrl}{OptionsUrl}";
        return url;
    }
}