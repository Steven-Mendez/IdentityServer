using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.UpdateMicrosoftId;

public class UpdateMicrosoftIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<UpdateMicrosoftIdResponse> ExecuteAsync(Guid id, string microsoftId)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);

        user.MicrosoftId = microsoftId;
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedBy = id;

        await unitOfWork.UserRepository.UpdateAsync(id, user);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<UpdateMicrosoftIdResponse>(user);

        return response;
    }
}