using AutoMapper;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUserByAzureAd;

/// <summary>
/// Handles the creation of a user based on Azure Active Directory user information.
/// </summary>
/// <param name="unitOfWork">The unit of work for database transactions.</param>
/// <param name="mapper">The AutoMapper instance for object-to-object mapping.</param>
public class CreateUserByAzureAdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    /// Executes the use case to create a new user based on Azure AD user data.
    /// </summary>
    /// <param name="azureAdUserDto">The Azure AD user data transfer object containing user information.</param>
    /// <returns>A task representing the asynchronous operation of creating a new user.</returns>
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