using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserById;

public class GetUserByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<GetUserByIdResponse> ExecuteAsync(Guid id)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

        var response = _mapper.Map<GetUserByIdResponse>(user);

        return response;
    }
}