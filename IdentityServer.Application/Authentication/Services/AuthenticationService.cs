﻿using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Application.Authentication.Services;

public class AuthenticationService(LocalAuthenticationUseCase localAuthenticationUseCase, IConfiguration configuration)
    : IAuthenticationService
{
    private const string BaseUrl = "https://login.microsoftonline.com/";
    private const string AuthorizeEndpoint = "/oauth2/v2.0/authorize";
    private const string ResponseTypeParam = "response_type=code";
    private const string ScopeParam = "scope=user.read";
    private const string OptionsUrl = $"&{ResponseTypeParam}&{ScopeParam}";
    private readonly string _clientId = GetValueFromConfiguration(configuration, "AzureAd:ClientId");

    private readonly string _frontEndUrl = GetValueFromConfiguration(configuration, "FrontendUrl");
    private readonly string _redirectUrl = GetValueFromConfiguration(configuration, "IdentityServerSettings:Url");
    private readonly string _tenantId = GetValueFromConfiguration(configuration, "AzureAd:TenantId");

    public async Task<LocalAuthenticationResponse> Authenticate(LocalAuthenticationRequest request)
    {
        var result = await localAuthenticationUseCase.ExecuteAsync(request);
        return result;
    }

    public string GetAzureAdUrl()
    {
        var clientIdParam = $"client_id={_clientId}";
        var redirectUriParam = $"redirect_uri={_redirectUrl}/api/Authentication/Oauth2.0/azure-ad/callback";

        var mainUrl = $"{BaseUrl}{_tenantId}{AuthorizeEndpoint}?";
        var paramsUrl = $"{clientIdParam}&{redirectUriParam}";


        var url = $"{mainUrl}{paramsUrl}{OptionsUrl}";

        return url;
    }

    public string GetFrontendUrl(string jwt)
    {
        var jwtParam = $"jwt={jwt}";
        var url = $"{_frontEndUrl}?{jwtParam}";
        return url;
    }

    private static string GetValueFromConfiguration(IConfiguration configuration, string key)
    {
        var value = configuration[key];
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(configuration),
                $"Configuration value for '{key}' is missing or empty.");
        return value;
    }
}