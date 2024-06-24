using AutoMapper;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUserByAzureAd.Maps;

public class CreateUserByAzureAdMapProfile : Profile
{
    public CreateUserByAzureAdMapProfile()
    {
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