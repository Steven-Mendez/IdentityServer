using AutoMapper;
using FluentValidation;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.UpdateUser;

public class UpdateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserRequest> validationRules)
{
    public async Task<UpdateUserResponse> ExecuteAsync(Guid id, UpdateUserRequest request)
    {
        await validationRules.ValidateAndThrowAsync(request);

        var user = await unitOfWork.UserRepository.GetByIdAsync(id);
        
        user = mapper.Map(request, user);

        await unitOfWork.UserRepository.UpdateAsync(id, user);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<UpdateUserResponse>(user);

        return response;
    }
}