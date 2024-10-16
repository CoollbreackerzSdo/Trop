using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using Trop.Domain.Models.User;

namespace Trop.Application;

public static partial class ServiceDiscovery
{
    public static IServiceCollection AddHandlers(this IServiceCollection service)
    {

        return service;
    }
    public static IServiceCollection AddHashService(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        return services;
    }
}