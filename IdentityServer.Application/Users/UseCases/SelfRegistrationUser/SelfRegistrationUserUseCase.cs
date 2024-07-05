using AutoMapper;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser;

public class SelfRegistrationUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<SelfRegistrationUserResponse> ExecuteAsync(SelfRegistrationUserRequest request)
    {
        var userToAdd = mapper.Map<User>(request);
        
        var user = await unitOfWork.UserRepository.AddAsync(userToAdd);
        
        await unitOfWork.SaveChangesAsync();
        
        var response = mapper.Map<SelfRegistrationUserResponse>(user);
        
        return response;
    }
}
