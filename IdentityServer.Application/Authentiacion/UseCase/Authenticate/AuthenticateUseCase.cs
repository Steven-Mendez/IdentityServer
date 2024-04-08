using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;
using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Responses;
using IdentityServer.Application.Authentiacion.UseCase.JsonWebTokenGeneration;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Authentiacion.UseCase.Authenticate;

public class AuthenticateUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JsonWebTokenGenerationUseCase _jsonWebTokenGenerationUseCase;

    public AuthenticateUseCase(IUnitOfWork unitOfWork, JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase)
    {
        _unitOfWork = unitOfWork;
        _jsonWebTokenGenerationUseCase = jsonWebTokenGenerationUseCase;
    }

    public async Task<AuthenticateResponse> ExecuteAsync(AuthenticateRequest request)
    {
        var user = await _unitOfWork.UserRepository.AuthenticateAsync(request.Login, request.Password);

        var jwt = _jsonWebTokenGenerationUseCase.Execute(user.Id, user.Email, user.FirstName!, user.LastName!);

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