using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Application.Authentication.Services;

public class LocalLocalAuthenticationService(
    LocalAuthenticationUseCase localAuthenticationUseCase,
    IConfiguration configuration)
    : ILocalAuthenticationService
{
    public async Task<LocalAuthenticationResponse> Authenticate(LocalAuthenticationRequest request)
    {
        var result = await localAuthenticationUseCase.ExecuteAsync(request);
        return result;
    }
}