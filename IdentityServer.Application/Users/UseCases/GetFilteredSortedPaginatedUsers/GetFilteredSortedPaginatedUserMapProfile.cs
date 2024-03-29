﻿using AutoMapper;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;

public class GetFilteredSortedPaginatedUserMapProfile : Profile
{
    public GetFilteredSortedPaginatedUserMapProfile()
    {
        CreateMap<User, GetFilteredSortedPaginatedUserResponse>();
        CreateMap<(IEnumerable<User> Users, int TotalRecords), GetFilteredSortedPaginatedUsersResponse>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
            .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords));
    }
}
