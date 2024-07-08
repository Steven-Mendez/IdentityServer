using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Options;
using IdentityServer.Application.Users.UseCases.CreateUserByAzureAd;
using IdentityServer.Application.Users.UseCases.GetUserByEmail;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId;
using Microsoft.Extensions.Options;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationCallback;

/// <summary>
///     Handles the callback from Azure AD authentication, managing user information retrieval,
///     user creation or update, and JWT token generation.
/// </summary>
/// <param name="options">Configuration options for frontend settings.</param>
/// <param name="createUserByAzureAdUseCase">The use case for creating a user by Azure AD information.</param>
/// <param name="getUserByEmailUseCase">The use case for getting a user by email.</param>
/// <param name="getUserByMicrosoftId">The use case for getting a user by Microsoft ID.</param>
/// <param name="updateMicrosoftIdUseCase">The use case for updating a user's Microsoft ID.</param>
/// <param name="azureAdGetUserInformationUseCase">The use case for getting user information from Azure AD.</param>
/// <param name="jsonWebTokenGenerationUseCase">The use case for generating a JSON Web Token.</param>
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

    /// <summary>
    ///     Executes the use case with the given authorization code to authenticate a user via Azure AD.
    /// </summary>
    /// <param name="code">The authorization code from Azure AD.</param>
    /// <returns>A URL redirecting to the frontend with the JWT token as a parameter.</returns>
    public async Task<string> Execute(string code)
    {
        var azureUser = await azureAdGetUserInformationUseCase.Execute(code);
        var userByMicrosoftId = await getUserByMicrosoftId.ExecuteAsync(azureUser.id);

        if (userByMicrosoftId is not null)
            return GetJwtToken(userByMicrosoftId.Id, userByMicrosoftId.Email, userByMicrosoftId.FirstName,
                userByMicrosoftId.LastName);

        // Check if the user is already registered with the email
        var userByEmail = await getUserByEmailUseCase.ExecuteAsync(azureUser.mail);

        // If the user is found by email, we need to update the user with the MicrosoftId
        if (userByEmail is not null)
            await updateMicrosoftIdUseCase.ExecuteAsync(userByEmail.Id, azureUser.id);
        // Otherwise, we need to create a new user
        else
            await createUserByAzureAdUseCase.ExecuteAsync(azureUser);

        userByMicrosoftId = await getUserByMicrosoftId.ExecuteAsync(azureUser.id);

        return GetJwtToken(userByMicrosoftId!.Id, userByMicrosoftId.Email, userByMicrosoftId.FirstName,
            userByMicrosoftId.LastName);
    }

    /// <summary>
    ///     Generates a JWT token for the authenticated user and constructs a URL to the frontend with the token.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <param name="email">The user's email address.</param>
    /// <param name="name">The user's first name.</param>
    /// <param name="lastName">The user's last name.</param>
    /// <returns>A URL to the frontend with the JWT token as a parameter.</returns>
    private string GetJwtToken(Guid id, string email, string name, string lastName)
    {
        var (token, _) = jsonWebTokenGenerationUseCase.Execute(id, email, name, lastName);
        var jwtParam = $"jwt={token}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }
}