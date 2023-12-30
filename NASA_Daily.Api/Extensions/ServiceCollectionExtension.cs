using System.Reflection;
using NASA_Daily.Domain.Services.Abstract;
using NASA_Daily.Domain.Services.Implementations;
using Serilog;

namespace NASA.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var fromType = typeof(IService);
            var serviceAssembly = Assembly.GetAssembly(typeof(NasaService));

            var serviceTypes = serviceAssembly.GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.Namespace) && x.IsClass && !x.IsAbstract &&
                            fromType.IsAssignableFrom(x))
                .Select(x => new
                {
                    Interface = x.GetInterface($"I{x.Name}"),
                    Implementation = x
                });
            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType.Interface, serviceType.Implementation);
            }

            return services;
        }

        public static IServiceCollection ConfigureSerilog(this IServiceCollection services, ConfigureHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            return services;
        }
    }
}