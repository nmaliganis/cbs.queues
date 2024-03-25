using cbs.common.infrastructure.PropertyMappings;
using cbs.common.infrastructure.TypeHelpers;
using cbs.queue.monitoring.api.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace cbs.queue.monitoring.api.Configurations;

internal static class Config
{
    internal static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITypeHelperService, TypeHelperService>();

        return services;
    }

    public static IServiceCollection AddCustomMvc(this IServiceCollection services)
    {
        // Add framework services.
        services.AddControllers(options =>
          {
              options.Filters.Add(typeof(HttpGlobalExceptionFilter));
          })
          // Added for functional tests
          .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
          builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        });

        return services;
    }
}//Class : Config