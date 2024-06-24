using AutoMapper;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUserByAzureAd;

public class CreateUserByAzureAdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task ExecuteAsync(AzureAdUserDto azureAdUserDto)
    {
        var userId = Guid.NewGuid();
        var user = mapper.Map<User>(azureAdUserDto);
        user.Id = userId;
        user.CreatedBy = userId;
        await unitOfWork.UserRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();
    }
}