using IdentityServer.Application.Authentication.Helpers;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

public class AzureAdAuthenticationCallbackUseCase(IConfiguration configuration, JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase)
{
    private readonly string _frontEndUrl = ConfigurationHelper.GetValueFromConfiguration(configuration, "FrontendUrl");
    
    public string Execute(string code)
    {
        var jwtParam = $"jwt={code}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}