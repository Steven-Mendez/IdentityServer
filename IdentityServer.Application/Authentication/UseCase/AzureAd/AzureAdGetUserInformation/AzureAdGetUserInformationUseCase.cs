using System.Net.Http.Headers;
using System.Net.Http.Json;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetToken;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation;

public class AzureAdGetUserInformationUseCase(
    IHttpClientFactory httpClient,
    AzureAdGetTokenUseCase azureAdGetTokenUseCase)
{
    private const string Scheme = "Bearer";
    private const string MicrosoftApiUrl = "https://graph.microsoft.com/v1.0/me";

    public async Task<AzureAdUserDto> Execute(string code)
    {
        var token = await azureAdGetTokenUseCase.Execute(code);
        var user = await GetUser(token.access_token);
        return user;
    }

    private async Task<AzureAdUserDto> GetUser(string token)
    {
        var azureClient = httpClient.CreateClient();
        azureClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, token);
        var user = await azureClient.GetFromJsonAsync<AzureAdUserDto>(MicrosoftApiUrl);
        return user!;
    }
}