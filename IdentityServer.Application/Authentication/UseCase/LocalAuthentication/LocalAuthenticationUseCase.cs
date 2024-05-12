using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Authentication.UseCase.LocalAuthentication;

public class LocalAuthenticationUseCase(
    IUnitOfWork unitOfWork,
    JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase)
{
    private const string TokenType = "Bearer";

    public async Task<LocalAuthenticationResponse> ExecuteAsync(LocalAuthenticationRequest request)
    {
        var user = await unitOfWork.UserRepository.AuthenticateAsync(request.Login, request.Password);

        var jwt = jsonWebTokenGenerationUseCase.Execute(user.Id, user.Email, user.FirstName!, user.LastName!);

        var response = new LocalAuthenticationResponse
        {
            Token = jwt.token,
            RefreshToken = Guid.NewGuid().ToString(),
            Expires = DateTime.UtcNow.AddMinutes(jwt.expirationMinutes),
            TokenType = TokenType
        };

        return response;
    }
}