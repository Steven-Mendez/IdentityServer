using AutoMapper;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUser;
public class CreateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest createUserRequest)
    {
        var userToAdd = _mapper.Map<User>(createUserRequest);

        var user = await _unitOfWork.UserRepository.AddAsync(userToAdd);

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<CreateUserResponse>(user);

        return response;
    }
}
