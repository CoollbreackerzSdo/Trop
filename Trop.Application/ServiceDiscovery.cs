using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using Trop.Application.Handlers;
using Trop.Application.Handlers.Create;
using Trop.Domain.Models.User;

namespace Trop.Application;

public static partial class ServiceDiscovery
{
    public static IServiceCollection AddHandlers(this IServiceCollection service)
    {
        service.AddTransient<IHandlerAsync<CreateUserCommandHandler, UserCredentials>,CreateUserHandler>();
        return service;
    }
    public static IServiceCollection AddHashers(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        return services;
    }
}