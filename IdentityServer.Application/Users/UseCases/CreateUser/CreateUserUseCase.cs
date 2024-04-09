using AutoMapper;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUser;

public class CreateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest createUserRequest)
    {
        var userToAdd = mapper.Map<User>(createUserRequest);

        var user = await unitOfWork.UserRepository.AddAsync(userToAdd);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<CreateUserResponse>(user);

        return response;
    }
}