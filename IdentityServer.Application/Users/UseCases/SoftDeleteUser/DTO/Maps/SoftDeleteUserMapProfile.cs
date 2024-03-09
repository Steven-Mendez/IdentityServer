using AutoMapper;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DTO.Response;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser.DTO.Maps;

public class SoftDeleteUserMapProfile : Profile
{
    public SoftDeleteUserMapProfile()
    {
        CreateMap<User, SoftDeleteUserResponse>();
    }
}
