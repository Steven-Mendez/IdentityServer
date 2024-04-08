using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUserById.Maps;

internal class GetUserByIdMapProfile : Profile
{
    public GetUserByIdMapProfile()
    {
        CreateMap<User, GetUserByIdResponse>();
    }
}