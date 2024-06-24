using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserByEmail;

public class GetUserByEmailUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetUserByEmailResponse?> ExecuteAsync(string email)
    {
        var user = await unitOfWork.UserRepository.GetByEmailAsync(email);
        var response = mapper.Map<GetUserByEmailResponse?>(user);
        return response;
    }
}