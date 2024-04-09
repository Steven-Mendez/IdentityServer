using AutoMapper;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser.Maps;

public class SoftDeleteUserMapProfile : Profile
{
    public SoftDeleteUserMapProfile()
    {
        CreateMap<User, SoftDeleteUserResponse>();
    }
}