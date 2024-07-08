using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;

namespace IdentityServer.Application.Authentication.Services;

/// <summary>
/// Provides services for authenticating users through local credentials.
/// </summary>
/// /// <param name="localAuthenticationUseCase">The use case for local authentication.</param>
public class LocalAuthenticationService(LocalAuthenticationUseCase localAuthenticationUseCase)
    : ILocalAuthenticationService
{
    /// <summary>
    /// Authenticates a user based on the provided local authentication request.
    /// </summary>
    /// <param name="request">The local authentication request containing user credentials.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authentication response.</returns>
    public async Task<LocalAuthenticationResponse> Authenticate(LocalAuthenticationRequest request)
    {
        var result = await localAuthenticationUseCase.ExecuteAsync(request);
        return result;
    }
}