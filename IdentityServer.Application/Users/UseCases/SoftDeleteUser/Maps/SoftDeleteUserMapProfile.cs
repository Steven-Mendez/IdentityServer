using AutoMapper;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser.Maps;

/// <summary>
///     Defines the AutoMapper profile for the Soft Delete User use case.
///     This profile is responsible for mapping from the User domain entity to the SoftDeleteUserResponse DTO.
/// </summary>
public class SoftDeleteUserMapProfile : Profile
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SoftDeleteUserMapProfile" /> class.
    ///     Configures the mapping from the User domain entity to the SoftDeleteUserResponse DTO.
    /// </summary>
    public SoftDeleteUserMapProfile()
    {
        CreateMap<User, SoftDeleteUserResponse>();
    }
}