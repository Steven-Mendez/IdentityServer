using AutoMapper;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DTO.Response;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser;

public class SoftDeleteUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<SoftDeleteUserResponse> ExecuteAsync(Guid userId)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

        await _unitOfWork.UserRepository.DeleteAsync(userId);

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<SoftDeleteUserResponse>(user);

        return response;
    }
}
