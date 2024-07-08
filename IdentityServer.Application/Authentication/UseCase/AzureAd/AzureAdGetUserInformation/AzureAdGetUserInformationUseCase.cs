using System.Net.Http.Headers;
using System.Net.Http.Json;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetToken;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation;

/// <summary>
/// Provides functionality to obtain user information from Azure AD using an access token.
/// </summary>
/// <param name="httpClient">The factory to create instances of <see cref="HttpClient"/>.</param>
/// <param name="azureAdGetTokenUseCase">The use case to obtain an Azure AD token.</param>
public class AzureAdGetUserInformationUseCase(
    IHttpClientFactory httpClient,
    AzureAdGetTokenUseCase azureAdGetTokenUseCase)
{
    private const string Scheme = "Bearer";
    private const string MicrosoftApiUrl = "https://graph.microsoft.com/v1.0/me";

    /// <summary>
    /// Asynchronously retrieves user information from Azure AD.
    /// </summary>
    /// <param name="code">The authorization code to exchange for an access token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the Azure AD user information.</returns>
    public async Task<AzureAdUserDto> Execute(string code)
    {
        var token = await azureAdGetTokenUseCase.Execute(code);
        var user = await GetUser(token.access_token);
        return user;
    }

    /// <summary>
    /// Asynchronously retrieves user information from Azure AD using the provided access token.
    /// </summary>
    /// <param name="token">The access token for Azure AD.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the Azure AD user information.</returns>
    private async Task<AzureAdUserDto> GetUser(string token)
    {
        var azureClient = httpClient.CreateClient();
        azureClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);
        var user = await azureClient.GetFromJsonAsync<AzureAdUserDto>(MicrosoftApiUrl);
        return user!;
    }
}