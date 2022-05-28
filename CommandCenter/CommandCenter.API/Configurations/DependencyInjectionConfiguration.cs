using CommandCenter.BLL.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.BLL.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.Core.Interfaces.Repositories;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.Core.Repositories;
using CommandCenter.Core.Resources;
using CommandCenter.DAL.PostgreSQL;
using CommandCenter.DAL.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CommandCenter.API.Configurations
{
    public abstract class DependencyInjectionConfiguration
    {
        protected readonly IConfiguration Configuration;

        public DependencyInjectionConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public abstract void RegisterConfigs(ref IServiceCollection services);

        public virtual void RegisterAll(ref IServiceCollection services)
        {
            RegisterConfigs(ref services);
            RegisterRepositories(ref services);
            RegisterCQRS(ref services);
        }

        // Repositories
        public virtual void RegisterRepositories(ref IServiceCollection services)
        {
            services.AddScoped(typeof(IDbProviderRepository<>), typeof(PostgreSQLRepository<>));
            services.AddScoped<IFrameworkRepository, FrameworkRepository>();
            services.AddScoped<IProtocolRepository, ProtocolRepository>();
        }

        public virtual void RegisterCQRS(ref IServiceCollection services)
        {
            // Handler
            services.AddScoped<IGetAllFrameworksHandler, GetAllFrameworksHandler>();
            services.AddScoped<IGetByIdFrameworkHandler, GetByIdFrameworkHandler>();

            // Query => Handler
            services.AddScoped<IRequestHandler<BaseGetAllQuery<FrameworkGetResource>, IEnumerable<FrameworkGetResource>>, GetAllFrameworksHandler>();
            services.AddScoped<IRequestHandler<BaseGetByIdQuery<FrameworkGetResource>, FrameworkGetResource>, GetByIdFrameworkHandler>();

            //Command => Handler

        }
    }
}
