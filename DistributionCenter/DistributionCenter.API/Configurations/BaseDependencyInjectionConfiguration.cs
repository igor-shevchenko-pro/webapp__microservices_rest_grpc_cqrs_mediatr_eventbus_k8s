using DistributionCenter.BLL.Services;
using DistributionCenter.Core.Interfaces.DataProviders;
using DistributionCenter.Core.Interfaces.Repositories;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using DistributionCenter.Core.Interfaces.Services;
using DistributionCenter.DAL.MSSQL;
using DistributionCenter.DAL.Repositories;
using DistributionCenter.DataProviders.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributionCenter.API.Configurations
{
    public abstract class BaseDependencyInjectionConfiguration
    {
        protected readonly IConfiguration Configuration;

        public BaseDependencyInjectionConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public abstract void RegisterConfigs(ref IServiceCollection services);

        public virtual void RegisterAll(ref IServiceCollection services)
        {
            RegisterConfigs(ref services);
            RegisterRepositories(ref services);
            RegisterServices(ref services);
            RegisterHttpClients(ref services);
        }

        // Repositories
        public virtual void RegisterRepositories(ref IServiceCollection services)
        {
            services.AddScoped(typeof(IDbProviderRepository<>), typeof(MSSQLRepository<>));
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IServerRepository, ServerRepository>();
        }

        // Services
        public virtual void RegisterServices(ref IServiceCollection services)
        {
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<IServerService, ServerService>();
        }

        // HttpClients
        public virtual void RegisterHttpClients(ref IServiceCollection services)
        {
            services.AddHttpClient<IPlatformHttpDataProvider, PlatformHttpDataProvider>();
        }
    }
}
