﻿using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetAllUsers.Maps;

public class GetAllUsersMapProfile : Profile
{
    public GetAllUsersMapProfile()
    {
        CreateMap<User, GetAllUsersResponse>();
    }
}
