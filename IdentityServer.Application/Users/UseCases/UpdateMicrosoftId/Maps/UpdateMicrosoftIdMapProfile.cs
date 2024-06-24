using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.Maps;

public class UpdateMicrosoftIdMapProfile : Profile
{
    public UpdateMicrosoftIdMapProfile()
    {
        CreateMap<User, UpdateMicrosoftIdResponse>();
    }
}