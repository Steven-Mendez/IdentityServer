using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.Maps;

public class GetUserByMicrosoftIdProfile : Profile
{
    public GetUserByMicrosoftIdProfile()
    {
        CreateMap<User, GetUserGetUserByMicrosoftIdResponse>();
    }
}