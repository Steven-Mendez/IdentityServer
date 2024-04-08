using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;
using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Responses;

namespace IdentityServer.Application.Authentiacion.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}