using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.Authenticate;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Responses;

namespace IdentityServer.Application.Authentication.Services;

public class AuthenticationService(AuthenticateUseCase authenticateUseCase) : IAuthenticationService
{
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var result = await authenticateUseCase.ExecuteAsync(request);
        return result;
    }
}