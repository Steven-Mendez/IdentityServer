using AutoMapper;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser.Maps;

/// <summary>
/// AutoMapper profile for the Self Registration User use case.
/// This class is responsible for configuring the mappings between the DTOs and the domain entities
/// involved in the self-registration process.
/// </summary>
public class SelfRegistrationUserMapProfile : Profile
{
    /// <summary>
    /// Configures the mappings between the SelfRegistrationUserRequest DTO, User domain entity,
    /// and SelfRegistrationUserResponse DTO.
    /// </summary>
    public SelfRegistrationUserMapProfile()
    {
        CreateMap<SelfRegistrationUserRequest, User>()
            .AfterMap((_, user) =>
            {
                var id = Guid.NewGuid();
                user.Id = id;
                user.CreatedBy = id;
            });
        CreateMap<User, SelfRegistrationUserResponse>();
    }
}