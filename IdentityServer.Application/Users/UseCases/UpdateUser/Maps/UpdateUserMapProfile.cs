using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.UpdateUser.Maps;

/// <summary>
///     Defines the AutoMapper profile for the Update User use case.
///     This profile is responsible for mapping between User domain entities and Data Transfer Objects (DTOs).
/// </summary>
public class UpdateUserMapProfile : Profile
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UpdateUserMapProfile" /> class.
    ///     Configures the mappings between User domain entities and DTOs.
    /// </summary>
    public UpdateUserMapProfile()
    {
        CreateMap<User, UpdateUserResponse>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(opt => opt.Condition((_, _, srcMember) => srcMember is not null));
    }
}