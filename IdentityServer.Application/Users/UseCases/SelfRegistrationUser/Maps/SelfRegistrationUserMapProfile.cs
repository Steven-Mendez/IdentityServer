using AutoMapper;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser.Maps;

public class SelfRegistrationUserMapProfile : Profile
{
    public SelfRegistrationUserMapProfile()
    {
        CreateMap<SelfRegistrationUserRequest, User>()
            .AfterMap((_, user) =>
            {
                var id = Guid.NewGuid();
                user.Id = id;
                user.CreatedBy = id;
            });
        CreateMap<User, SelfRegistrationUserResponse>();
    }
}