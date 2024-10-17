using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Trop.Application.Common.Repository;
using Trop.Infrastructure.Context;

namespace Trop.Infrastructure;

public static partial class ServicesDiscovery
{
    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<TropContext>(options =>
        {
            options.UseNpgsql(Environment.GetEnvironmentVariable("NPSQL_CONNECTION") ?? throw new ArgumentException("Variable de entorno [NPSQL_CONNECTION] no configurada."), x => x.MigrationsAssembly("Trop.Api"));
        });
        return services;
    }

    public static IServiceCollection AddUnitOfWord(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWord, TropUnitOfWord>();
        return services;
    }
}