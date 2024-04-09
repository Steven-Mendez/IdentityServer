using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.UpdateUser.Maps;

public class UpdateUserMapProfile : Profile
{
    public UpdateUserMapProfile()
    {
        CreateMap<User, UpdateUserResponse>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(opt => opt.Condition((_, _, srcMember) => srcMember is not null));
    }
}