using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserById;

public class GetUserByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetUserByIdResponse> ExecuteAsync(Guid id)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);

        var response = mapper.Map<GetUserByIdResponse>(user);

        return response;
    }
}