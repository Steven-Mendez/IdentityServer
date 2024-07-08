using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUserById.Maps;

/// <summary>
///     AutoMapper profile for mapping domain entities to data transfer objects (DTOs) for the GetUserById use case.
/// </summary>
internal class GetUserByIdMapProfile : Profile
{
    /// <summary>
    ///     Configures the mappings between User domain entities and GetUserByIdResponse DTOs.
    /// </summary>
    public GetUserByIdMapProfile()
    {
        CreateMap<User, GetUserByIdResponse>();
    }
}