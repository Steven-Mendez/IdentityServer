using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUserByEmail.Maps;

public class GetUserByEmailMapProfile : Profile
{
    public GetUserByEmailMapProfile()
    {
        CreateMap<User, GetUserByEmailResponse>();
    }
}