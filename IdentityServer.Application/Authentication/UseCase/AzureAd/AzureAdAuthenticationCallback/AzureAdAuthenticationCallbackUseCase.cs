using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Options;
using IdentityServer.Application.Users.UseCases.GetUserByEmail;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationCallback;

public class AzureAdAuthenticationCallbackUseCase(
    IOptions<FrontendSettings> options,
    GetUserByEmailUseCase getUserByEmailUseCase,
    AzureAdGetUserInformationUseCase azureAdGetUserInformationUseCase,
    JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase
)
{
    private readonly string _frontEndUrl = options.Value.Url;

    public async Task<string> Execute(string code)
    {
        var azureUser = await azureAdGetUserInformationUseCase.Execute(code);

        var user = await getUserByEmailUseCase.ExecuteAsync(azureUser.mail);

        if (user is null)
        {
            // Todo: Code CreateUserByAzureUserUse
        }
        
        var (token, _) = jsonWebTokenGenerationUseCase.Execute(user!.Id, user.Email, user.FirstName!, user.LastName!);
        var jwtParam = $"jwt={token}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}