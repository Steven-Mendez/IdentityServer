using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationCallback;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationRedirect;

namespace IdentityServer.Application.Authentication.Services;

public class AzureAdAuthenticationService(
    AzureAdAuthenticationRedirectUseCase azureAdAuthenticationRedirectUseCase,
    AzureAdAuthenticationCallbackUseCase azureAdAuthenticationCallbackUseCase)
    : IAzureAuthenticationService
{
    public string Redirect()
    {
        var url = azureAdAuthenticationRedirectUseCase.Execute();
        return url;
    }

    public async Task<string> Callback(string code)
    {
        var url = await azureAdAuthenticationCallbackUseCase.Execute(code);
        return url;
    }
}