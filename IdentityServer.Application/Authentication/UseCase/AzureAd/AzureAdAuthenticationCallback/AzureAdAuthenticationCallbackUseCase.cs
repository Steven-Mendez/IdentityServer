using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Options;
using IdentityServer.Application.Users.UseCases.CreateUserByAzureAd;
using IdentityServer.Application.Users.UseCases.GetUserByEmail;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationCallback;

public class AzureAdAuthenticationCallbackUseCase(
    IOptions<FrontendSettings> options,
    CreateUserByAzureAdUseCase createUserByAzureAdUseCase,
    GetUserByEmailUseCase getUserByEmailUseCase,
    GetUserByMicrosoftId getUserByMicrosoftId,
    UpdateMicrosoftIdUseCase updateMicrosoftIdUseCase,
    AzureAdGetUserInformationUseCase azureAdGetUserInformationUseCase,
    JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase
)
{
    private readonly string _frontEndUrl = options.Value.Url;

    public async Task<string> Execute(string code)
    {
        var azureUser = await azureAdGetUserInformationUseCase.Execute(code);
        var userByMicrosoftId = await getUserByMicrosoftId.ExecuteAsync(azureUser.id);

        if (userByMicrosoftId is not null)
            return GetJwtToken(userByMicrosoftId!.Id, userByMicrosoftId.Email, userByMicrosoftId.FirstName!,
                userByMicrosoftId.LastName!);

        // Check if the user is already registered with the email
        var userByEmail = await getUserByEmailUseCase.ExecuteAsync(azureUser.mail);

        // If the user is found by email, we need to update the user with the MicrosoftId
        if (userByEmail is not null)
            await updateMicrosoftIdUseCase.ExecuteAsync(userByEmail.Id, azureUser.id);
        // Otherwise, we need to create a new user
        else
            await createUserByAzureAdUseCase.ExecuteAsync(azureUser);

        userByMicrosoftId = await getUserByMicrosoftId.ExecuteAsync(azureUser.id);

        return GetJwtToken(userByMicrosoftId!.Id, userByMicrosoftId.Email, userByMicrosoftId.FirstName!,
            userByMicrosoftId.LastName!);
    }

    private string GetJwtToken(Guid id, string email, string name, string lastName)
    {
        var (token, _) = jsonWebTokenGenerationUseCase.Execute(id, email, name, lastName);
        var jwtParam = $"jwt={token}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}