using IdentityServer.Application.Authentication.Services;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Options;
using IdentityServer.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAdAuthentication;

public class AzureAdAuthenticationCallbackUseCase(
    IOptions<FrontendSettings> options,
    IUnitOfWork unitOfWork,
    AzureAdService azureAdService,
    JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase
)
{
    private readonly string _frontEndUrl = options.Value.Url;

    public async Task<string> Execute(string code)
    {
        var azureUser = await azureAdService.GetUser(code);
        // Todo: Code GetUserByEmailUseCase
        var user = await unitOfWork.UserRepository.GetByEmailAsync(azureUser!.mail);
        // Todo: Code CreateUserByAzureUserUse if user not exists in dataBase
        var (token, _) = jsonWebTokenGenerationUseCase.Execute(user!.Id, user.Email, user.FirstName!, user.LastName!);
        var jwtParam = $"jwt={token}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}