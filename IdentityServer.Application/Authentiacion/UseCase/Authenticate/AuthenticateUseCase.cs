using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Authentiacion.UseCase.Authenticate;

public class AuthenticateUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticateUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // TODO: Token Generation
    public async Task<bool> ExecuteAsync(AuthenticateRequest request)
    {
        var user = await _unitOfWork.UserRepository.AuthenticateAsync(request.Login, request.Password);
        return user is not null;
    }
}
