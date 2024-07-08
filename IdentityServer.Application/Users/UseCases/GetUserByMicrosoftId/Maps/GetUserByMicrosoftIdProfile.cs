using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.Maps;

/// <summary>
///     AutoMapper profile for mapping domain entities to data transfer objects (DTOs) for the GetUserByMicrosoftId use
///     case.
/// </summary>
public class GetUserByMicrosoftIdProfile : Profile
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GetUserByMicrosoftIdProfile" /> class.
    ///     Configures the AutoMapper mapping between the User domain entity and the GetUserGetUserByMicrosoftIdResponse DTO.
    /// </summary>
    public GetUserByMicrosoftIdProfile()
    {
        CreateMap<User, GetUserGetUserByMicrosoftIdResponse>();
    }
}