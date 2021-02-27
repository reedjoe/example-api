using Example.Service.Converters;
using Example.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Service
{
    public static class ServiceRegistry
    {
        public static void ConfigureAll(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureConverters(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void ConfigureConverters(IServiceCollection services)
        {
            services.AddScoped<IUserConverter, UserConverter>();
        }
    }
}
