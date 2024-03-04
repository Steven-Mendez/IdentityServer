using AutoMapper;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUser.Maps;

public class CreateUserMapProfile : Profile
{
    public CreateUserMapProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}
