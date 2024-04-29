using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUsers.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsers.Maps;

public class GetUserMapProfile : Profile
{
    public GetUserMapProfile()
    {
        CreateMap<User, GetUserResponse>();
        CreateMap<(IEnumerable<User> Users, int TotalRecords),
                GetUsersResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
            .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords));
    }
}