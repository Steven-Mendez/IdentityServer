using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Responses;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Authentication.UseCase.Authenticate;

public class AuthenticateUseCase(IUnitOfWork unitOfWork, JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase)
{
    public async Task<AuthenticateResponse> ExecuteAsync(AuthenticateRequest request)
    {
        var user = await unitOfWork.UserRepository.AuthenticateAsync(request.Login, request.Password);

        var jwt = jsonWebTokenGenerationUseCase.Execute(user.Id, user.Email, user.FirstName!, user.LastName!);

        var response = new AuthenticateResponse
        {
            Token = jwt.token,
            RefreshToken = Guid.NewGuid().ToString(),
            Expires = DateTime.UtcNow.AddMinutes(jwt.expirationMinutes),
            TokenType = "Bearer"
        };

        return response;
    }
}