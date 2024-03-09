using FluentValidation;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.Services;
using IdentityServer.Application.Users.UseCases.CreateUser;
using IdentityServer.Application.Users.UseCases.GetAllUsers;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser;
using IdentityServer.Application.Users.UseCases.UpdateUser;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddUseCases();
        services.AddServices();
        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetAllUsersUseCase>();
        services.AddScoped<GetUserByIdUseCase>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<UpdateUserUseCase>();
        services.AddScoped<SoftDeleteUserUseCase>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
