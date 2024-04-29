using AutoMapper;
using FluentValidation;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUser;

public class CreateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserRequest> validationRules)
{
    public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request)
    {
        await validationRules.ValidateAndThrowAsync(request);

        var userToAdd = mapper.Map<User>(request);

        var user = await unitOfWork.UserRepository.AddAsync(userToAdd);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<CreateUserResponse>(user);

        return response;
    }
}