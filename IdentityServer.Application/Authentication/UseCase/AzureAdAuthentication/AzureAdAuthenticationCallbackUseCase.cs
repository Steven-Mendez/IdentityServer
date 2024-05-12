using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

public class AzureAdAuthenticationCallbackUseCase(
    IOptions<FrontendSettings> options,
    JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase)
{
    private readonly string _frontEndUrl = options.Value.Url;

    public string Execute(string code)
    {
        var jwtParam = $"jwt={code}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}