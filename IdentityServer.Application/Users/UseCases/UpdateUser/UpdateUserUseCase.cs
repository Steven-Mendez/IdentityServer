using AutoMapper;
using FluentValidation;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Responses;
using IdentityServer.Application.Users.UseCases.UpdateUser.Validators;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.UpdateUser;

public class UpdateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper, UpdateUserRequestValidator validationRules)
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdateUserRequest> _validationRules = validationRules;

    public async Task<UpdateUserResponse> ExecuteAsync(Guid id, UpdateUserRequest request)
    {
        await _validationRules.ValidateAndThrowAsync(request);

        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

        user = _mapper.Map(request, user);

        await _unitOfWork.UserRepository.UpdateAsync(id, user);

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateUserResponse>(user);

        return response;
    }
}