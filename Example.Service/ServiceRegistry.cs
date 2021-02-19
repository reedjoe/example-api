using Example.Service.Converters;
using Example.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Service
{
    public class ServiceRegistry
    {
        private IServiceCollection services;

        public ServiceRegistry(IServiceCollection services)
        {
            this.services = services;
        }

        public void ConfigureAllServices()
        {
            this.ConfigureServices();
            this.ConfigureConverters();
        }

        private void ConfigureServices()
        {
            this.services.AddScoped<IUserService, UserService>();
        }

        private void ConfigureConverters()
        {
            this.services.AddScoped<IUserConverter, UserConverter>();
        }
    }
}
