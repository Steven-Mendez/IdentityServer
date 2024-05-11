using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Maps;

public class GetUsersByCriteriaMapProfile : Profile
{
    public GetUsersByCriteriaMapProfile()
    {
        CreateMap<User, GetUserByCriteriaResponse>();
        CreateMap<(IEnumerable<User> Items, int TotalRecords),
                GetUsersByCriteriaResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords));
    }
}