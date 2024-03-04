using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
using IdentityServer.Domain.Users.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserById;
public class GetUserByIdUseCase(IUserRepository userRepository, IMapper mapper)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GetUserByIdResponse> ExecuteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        var response = _mapper.Map<GetUserByIdResponse>(user);

        return response;
    }
}
