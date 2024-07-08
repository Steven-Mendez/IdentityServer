using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.Maps;

/// <summary>
/// Defines the AutoMapper profile for the Update Microsoft ID use case.
/// This profile is responsible for mapping from the User domain entity to the UpdateMicrosoftIdResponse DTO.
/// </summary>
public class UpdateMicrosoftIdMapProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateMicrosoftIdMapProfile"/> class.
    /// Configures the mapping from the User domain entity to the UpdateMicrosoftIdResponse DTO.
    /// </summary>
    public UpdateMicrosoftIdMapProfile()
    {
        CreateMap<User, UpdateMicrosoftIdResponse>();
    }
}