using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationCallback;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationRedirect;

namespace IdentityServer.Application.Authentication.Services;

/// <summary>
///     Provides services for authenticating users through Azure Active Directory.
/// </summary>
/// <param name="azureAdAuthenticationRedirectUseCase">The use case for redirecting to Azure AD authentication.</param>
/// <param name="azureAdAuthenticationCallbackUseCase">The use case for handling the callback from Azure AD authentication.</param>
public class AzureAdAuthenticationService(
    AzureAdAuthenticationRedirectUseCase azureAdAuthenticationRedirectUseCase,
    AzureAdAuthenticationCallbackUseCase azureAdAuthenticationCallbackUseCase)
    : IAzureAuthenticationService
{
    /// <summary>
    ///     Redirects the user to the Azure AD login page.
    /// </summary>
    /// <returns>A URL to the Azure AD login page.</returns>
    public string Redirect()
    {
        var url = azureAdAuthenticationRedirectUseCase.Execute();
        return url;
    }

    /// <summary>
    ///     Handles the callback from Azure AD after the user has authenticated.
    /// </summary>
    /// <param name="code">The authorization code returned by Azure AD.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authentication token.</returns>
    public async Task<string> Callback(string code)
    {
        var url = await azureAdAuthenticationCallbackUseCase.Execute(code);
        return url;
    }
}