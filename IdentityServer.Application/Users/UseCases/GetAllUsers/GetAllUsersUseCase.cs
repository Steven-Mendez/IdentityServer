using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DTO.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetAllUsers;

public class GetAllUsersUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<GetAllUsersResponse>> ExecuteAsync()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();
        var response = _mapper.Map<IEnumerable<GetAllUsersResponse>>(users);
        return response;
    }
}