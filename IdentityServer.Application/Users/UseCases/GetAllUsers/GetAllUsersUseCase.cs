using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetAllUsers;

public class GetAllUsersUseCase(IUserRepository userRepository, IMapper mapper)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<GetAllUsersResponse>> ExecuteAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var response = _mapper.Map<IEnumerable<GetAllUsersResponse>>(users);
        return response;
    }
}
