using AutoMapper;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser;

public class SoftDeleteUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<SoftDeleteUserResponse> ExecuteAsync(Guid userId)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(userId);

        await unitOfWork.UserRepository.DeleteAsync(userId);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<SoftDeleteUserResponse>(user);

        return response;
    }
}