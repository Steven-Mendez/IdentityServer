using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUserByEmail.Maps;

/// <summary>
/// Defines the AutoMapper profile for mapping between User domain entities and GetUserByEmailResponse DTOs.
/// </summary>
public class GetUserByEmailMapProfile : Profile
{
    /// <summary>
    /// Configures the mapping profile.
    /// </summary>
    public GetUserByEmailMapProfile()
    {
        CreateMap<User, GetUserByEmailResponse>();
    }
}