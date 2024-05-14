using System.Net.Http.Headers;
using System.Net.Http.Json;
using IdentityServer.Application.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace IdentityServer.Application.Authentication.Services;

public class AzureAdService(
    HttpClient azureClient,
    IOptions<AzureAdSettings> options,
    IHttpClientFactory httpClientFactory)
{
    private const string GrantType = "authorization_code";
    private readonly string _clientId = options.Value.ClientId;
    private readonly string _clientSecret = options.Value.ClientSecret;
    private readonly string _redirectUrl = options.Value.RedirectUrl;
    private readonly string _tenantId = options.Value.TenantId;

    public async Task<AzureUser?> GetUser(string code)
    {
        var token = await GetToken(code);
        azureClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token!.access_token);
        var content = await azureClient.GetFromJsonAsync<AzureUser>("v1.0/me");
        return content;
    }

    private async Task<AzureToken?> GetToken(string code)
    {
        using var client = new RestClient($"https://login.microsoftonline.com/{_tenantId}/oauth2/v2.0/token");
        var request = new RestRequest { Method = Method.Post };
        request.AddParameter("grant_type", GrantType);
        request.AddParameter("code", code);
        request.AddParameter("redirect_uri", _redirectUrl);
        request.AddParameter("client_id", _clientId);
        request.AddParameter("client_secret", _clientSecret);

        var response = await client.ExecuteAsync(request);

        var content = response.Content;

        var token = JsonConvert.DeserializeObject<AzureToken>(content!);

        return token;
    }
}

public record AzureUser(
    List<string> businessPhones,
    string displayName,
    string givenName,
    string jobTitle,
    string mail,
    string mobilePhone,
    string officeLocation,
    string preferredLanguage,
    string surname,
    string userPrincipalName,
    string id
);

// ReSharper disable once InconsistentNaming
// ReSharper disable once NotAccessedPositionalProperty.Global
public record AzureToken(string access_token);