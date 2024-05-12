using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;

namespace IdentityServer.Application.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<LocalAuthenticationResponse> Authenticate(LocalAuthenticationRequest request);
    string GetAzureAdUrl();
    string GetFrontendUrl(string jwt);
}