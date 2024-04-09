using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetAllUsers;

public class GetAllUsersUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<IEnumerable<GetAllUsersResponse>> ExecuteAsync()
    {
        var users = await unitOfWork.UserRepository.GetAllAsync();
        var response = mapper.Map<IEnumerable<GetAllUsersResponse>>(users);
        return response;
    }
}