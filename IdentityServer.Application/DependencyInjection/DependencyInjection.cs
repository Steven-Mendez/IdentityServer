using FluentValidation;
using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.Services;
using IdentityServer.Application.Authentication.UseCase.Authenticate;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.Services;
using IdentityServer.Application.Users.UseCases.CreateUser;
using IdentityServer.Application.Users.UseCases.GetAllUsers;
using IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser;
using IdentityServer.Application.Users.UseCases.UpdateUser;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddAuthenticationUseCases();
        services.AddUserUseCases();
        services.AddServices();
    }

    private static void AddAuthenticationUseCases(this IServiceCollection services)
    {
        services.AddScoped<AuthenticateUseCase>();
        services.AddScoped<JsonWebTokenGenerationUseCase>();
    }

    private static void AddUserUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetAllUsersUseCase>();
        services.AddScoped<GetFilteredSortedPaginatedUsersUseCase>();
        services.AddScoped<GetUserByIdUseCase>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<UpdateUserUseCase>();
        services.AddScoped<SoftDeleteUserUseCase>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}