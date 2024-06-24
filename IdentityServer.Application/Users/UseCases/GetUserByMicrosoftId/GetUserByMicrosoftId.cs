using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId;

public class GetUserByMicrosoftId(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetUserGetUserByMicrosoftIdResponse?> ExecuteAsync(string microsoftId)
    {
        var user = await unitOfWork.UserRepository.GetByMicrosoftIdAsync(microsoftId);
        var response = mapper.Map<GetUserGetUserByMicrosoftIdResponse?>(user);
        return response;
    }
}