using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;

namespace IdentityServer.Application.Authentication.Interfaces;

public interface ILocalAuthenticationService
{
    Task<LocalAuthenticationResponse> Authenticate(LocalAuthenticationRequest request);
}