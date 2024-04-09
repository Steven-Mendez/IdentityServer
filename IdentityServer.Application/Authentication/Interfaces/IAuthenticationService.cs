using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Responses;

namespace IdentityServer.Application.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}