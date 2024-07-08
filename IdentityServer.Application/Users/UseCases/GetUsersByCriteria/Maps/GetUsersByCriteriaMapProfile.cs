using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Maps;

/// <summary>
/// Provides mapping configurations for user-related data transfer objects in the context of retrieving users by criteria.
/// </summary>
public class GetUsersByCriteriaMapProfile : Profile
{
    /// <summary>
    /// Configures AutoMapper profiles for mapping between User domain entities and DTOs for user retrieval by criteria.
    /// </summary>
    public GetUsersByCriteriaMapProfile()
    {
        CreateMap<User, GetUserByCriteriaResponse>();
        CreateMap<(IEnumerable<User> Items, int TotalRecords),
                GetUsersByCriteriaResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords));
    }
}