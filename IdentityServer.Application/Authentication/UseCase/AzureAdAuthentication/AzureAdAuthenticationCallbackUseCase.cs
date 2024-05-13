using IdentityServer.Application.Authentication.Services;
using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

public class AzureAdAuthenticationCallbackUseCase(
    IOptions<FrontendSettings> options,
    AzureAdService azureAdService)
{
    private readonly string _frontEndUrl = options.Value.Url;

    public async Task<string> Execute(string code)
    {
        var user = await azureAdService.GetUser(code, "authorization_code");
        var jwtParam = $"jwt={user!.mail}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}