using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;

namespace IdentityServer.Application.Authentiacion.Interfaces;

public interface IAuthenticationService
{
    Task<bool> Authenticate(AuthenticateRequest request);
}