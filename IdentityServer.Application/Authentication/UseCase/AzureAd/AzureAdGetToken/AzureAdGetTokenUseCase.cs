using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetToken.DataTransferObjects;
using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetToken;

public class AzureAdGetTokenUseCase(IOptions<AzureAdSettings> options)
{
    private const string GrantType = "authorization_code";
    private readonly string _clientId = options.Value.ClientId;
    private readonly string _clientSecret = options.Value.ClientSecret;
    private readonly string _redirectUrl = options.Value.RedirectUrl;
    private readonly string _tenantId = options.Value.TenantId;
    
    public async Task<AzureAdTokenDto> Execute(string code)
    {
        using var client = new RestClient($"https://login.microsoftonline.com/{_tenantId}/oauth2/v2.0/token");
        var request = new RestRequest { Method = Method.Post };
        request.AddParameter("grant_type", GrantType);
        request.AddParameter("code", code);
        request.AddParameter("redirect_uri", _redirectUrl);
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);

        var response = await client.ExecuteAsync(request);

        var content = response.Content!;

        var token = JsonConvert.DeserializeObject<AzureAdTokenDto>(content);

        return token!;
    }
}