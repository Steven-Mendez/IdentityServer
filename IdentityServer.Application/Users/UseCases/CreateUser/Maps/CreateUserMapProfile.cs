using AutoMapper;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUser.Maps;

/// <summary>
/// AutoMapper profile for creating user mappings.
/// This class is responsible for configuring the mappings between the CreateUserRequest DTO,
/// the User entity, and the CreateUserResponse DTO. It inherits from the AutoMapper Profile class.
/// </summary>
public class CreateUserMapProfile : Profile
{
    /// <summary>
    /// Configures the mappings between DTOs and the User entity.
    /// </summary>
    public CreateUserMapProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}