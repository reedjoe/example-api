using Microsoft.Extensions.DependencyInjection;

namespace Example.Data
{
    public static class DataRegistry
    {
        public static void ConfigureAll(IServiceCollection services)
        {
            ConfigureRepositories(services);
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
