using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Trop.Infrastructure.Context;

namespace Trop.Infrastructure;

public static partial class ServicesDiscovery
{
    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<TropContext>(options =>
        {
            options.UseNpgsql(Environment.GetEnvironmentVariable("NPSQL_CONNECTION"),x => x.MigrationsAssembly("Trop.Api"));
        });
        return services;
    }
}