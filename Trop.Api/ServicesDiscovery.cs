using Microsoft.Extensions.DependencyInjection.Extensions;

using Trop.Api.Endpoints;

namespace Trop.Api;

internal static partial class ServicesDiscovery
{
    public static IConfiguration ConfigureEnvs(this ConfigurationManager configuration)
    {
        configuration.AddEnvironmentVariables("STRIPE_PRIVATE_TOKEN");
        configuration.AddEnvironmentVariables("NPSQL_CONNECTION");
        return configuration;
    }
    public static IServiceCollection AddRedisCaching(this IServiceCollection service)
    {

        return service;
    }
    public static IServiceCollection AddEndpoints(this IServiceCollection service)
    {
        service.TryAddEnumerable(typeof(Program).Assembly.DefinedTypes.Where(x => !x.IsInterface && !x.IsAbstract && x.IsAssignableTo(typeof(IEndpoint))).Select(x => ServiceDescriptor.Transient(typeof(IEndpoint), x)));
        return service;
    }
    public static IEndpointRouteBuilder MapEndpoints(this WebApplication app)
    {
        foreach (var end in app.Services.GetService<IEnumerable<IEndpoint>>()!) end.Map(app);
        return app;
    }
}