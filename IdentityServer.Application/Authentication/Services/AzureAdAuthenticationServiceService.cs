using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

namespace IdentityServer.Application.Authentication.Services;

public class AzureAdAuthenticationServiceService(
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