using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;

namespace IdentityServer.Application.Authentication.Interfaces;

/// <summary>
/// Defines the contract for local authentication services.
/// </summary>
public interface ILocalAuthenticationService
{
    /// <summary>
    /// Authenticates a user based on the provided local authentication request.
    /// </summary>
    /// <param name="request">The local authentication request containing user credentials.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authentication response.</returns>
    Task<LocalAuthenticationResponse> Authenticate(LocalAuthenticationRequest request);
}