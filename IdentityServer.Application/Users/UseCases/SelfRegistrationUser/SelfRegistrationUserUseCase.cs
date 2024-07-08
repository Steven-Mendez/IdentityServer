using AutoMapper;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser;

/// <summary>
///     Handles the self-registration process for new users.
/// </summary>
/// <param name="unitOfWork">The unit of work for database transactions.</param>
/// <param name="mapper">The AutoMapper instance for object mapping.</param>
public class SelfRegistrationUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    ///     Executes the self-registration process for a new user.
    /// </summary>
    /// <param name="request">The self-registration request containing user details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the self-registration response.</returns>
    public async Task<SelfRegistrationUserResponse> ExecuteAsync(SelfRegistrationUserRequest request)
    {
        var userToAdd = mapper.Map<User>(request);

        var user = await unitOfWork.UserRepository.AddAsync(userToAdd);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<SelfRegistrationUserResponse>(user);

        return response;
    }
}