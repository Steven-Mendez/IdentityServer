using FluentValidation;
using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.Services;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationCallback;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdAuthenticationRedirect;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetToken;
using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation;
using IdentityServer.Application.Authentication.UseCase.JsonWebTokenGeneration;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.Services;
using IdentityServer.Application.Users.UseCases.CreateUser;
using IdentityServer.Application.Users.UseCases.CreateUserByAzureAd;
using IdentityServer.Application.Users.UseCases.GetUserByEmail;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId;
using IdentityServer.Application.Users.UseCases.UpdateUser;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Application.DependencyInjection;

/// <summary>
/// Provides extension methods for IServiceCollection to add application services and use cases.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds application services, use cases, and AutoMapper configurations to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddAuthenticationUseCases();
        services.AddUserUseCases();
        services.AddServices();
    }

    /// <summary>
    /// Adds authentication-related use cases to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    private static void AddAuthenticationUseCases(this IServiceCollection services)
    {
        services.AddScoped<LocalAuthenticationUseCase>();
        services.AddScoped<AzureAdAuthenticationRedirectUseCase>();
        services.AddScoped<AzureAdAuthenticationCallbackUseCase>();
        services.AddScoped<AzureAdGetTokenUseCase>();
        services.AddScoped<AzureAdGetUserInformationUseCase>();
        services.AddScoped<JsonWebTokenGenerationUseCase>();
    }

    /// <summary>
    /// Adds user-related use cases to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    private static void AddUserUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetUsersByCriteriaUseCase>();
        services.AddScoped<GetUserByIdUseCase>();
        services.AddScoped<GetUserByEmailUseCase>();
        services.AddScoped<GetUserByMicrosoftId>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<CreateUserByAzureAdUseCase>();
        services.AddScoped<SelfRegistrationUserUseCase>();
        services.AddScoped<UpdateUserUseCase>();
        services.AddScoped<UpdateMicrosoftIdUseCase>();
        services.AddScoped<SoftDeleteUserUseCase>();
    }

    /// <summary>
    /// Adds scoped services to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILocalAuthenticationService, LocalAuthenticationService>();
        services.AddScoped<IAzureAuthenticationService, AzureAdAuthenticationService>();
    }
}