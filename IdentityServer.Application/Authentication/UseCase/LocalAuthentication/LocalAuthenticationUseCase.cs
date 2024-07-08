using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Authentication.UseCase.LocalAuthentication;

/// <summary>
/// Handles the local authentication process.
/// </summary>
/// <param name="unitOfWork">The unit of work for database operations.</param>
/// <param name="jsonWebTokenGenerationUseCase">The use case for generating JSON Web Tokens.</param>
public class LocalAuthenticationUseCase(
    IUnitOfWork unitOfWork,
    JsonWebTokenGenerationUseCase jsonWebTokenGenerationUseCase)
{
    private const string TokenType = "Bearer";

    /// <summary>
    /// Executes the local authentication process asynchronously.
    /// </summary>
    /// <param name="request">The local authentication request containing login and password.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the local authentication response.</returns>
    public async Task<LocalAuthenticationResponse> ExecuteAsync(LocalAuthenticationRequest request)
    {
        var user = await unitOfWork.UserRepository.AuthenticateAsync(request.Login, request.Password);

        var jwt = jsonWebTokenGenerationUseCase.Execute(user.Id, user.Email!, user.FirstName, user.LastName!);

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