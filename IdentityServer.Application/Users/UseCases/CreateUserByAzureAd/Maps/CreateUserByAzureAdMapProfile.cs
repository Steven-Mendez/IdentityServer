using AutoMapper;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUserByAzureAd.Maps;

/// <summary>
///     Defines the mapping profile for creating a user from Azure Active Directory user data.
/// </summary>
public class CreateUserByAzureAdMapProfile : Profile
{
    /// <summary>
    ///     Configures the mappings between AzureAdUserDto and User domain entity.
    /// </summary>
    public CreateUserByAzureAdMapProfile()
    {
        // Maps properties from AzureAdUserDto to User, ignoring the ID property in the destination.
        CreateMap<AzureAdUserDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.mail))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.givenName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.surname))
            .ForMember(dest => dest.MicrosoftId, opt => opt.MapFrom(src => src.id))
            .AfterMap((_, dest) =>
            {
                var userId = Guid.NewGuid();
                dest.Id = userId;
                dest.CreatedBy = userId;
            });
    }
}