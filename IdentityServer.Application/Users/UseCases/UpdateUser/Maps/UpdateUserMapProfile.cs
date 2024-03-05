using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.UpdateUser.Maps;

public class UpdateUserMapProfile : Profile
{
    public UpdateUserMapProfile()
    {
        CreateMap<User, UpdateUserResponse>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember is not null));
    }
}
