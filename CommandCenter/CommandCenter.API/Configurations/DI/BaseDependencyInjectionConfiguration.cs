using CommandCenter.BLL.CQRS.Commands.Base;
using CommandCenter.BLL.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.BLL.CQRS.Handlers.ProtocolHandlers;
using CommandCenter.BLL.CQRS.Queries.Base;
using CommandCenter.BLL.EventSenderHubs;
using CommandCenter.Core.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache;
using CommandCenter.Core.Interfaces.Caches.EventSenderHubConnectionsCache.Base;
using CommandCenter.Core.Interfaces.CQRS.Handlers.FrameworkHandlers;
using CommandCenter.Core.Interfaces.CQRS.Handlers.ProtocolHandlers;
using CommandCenter.Core.Interfaces.EventSenderHubs;
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

namespace CommandCenter.API.Configurations.DI
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
            RegisterCQRS(ref services);
            RegisterHubEventSenders(ref services);
        }

        // Repositories
        public virtual void RegisterRepositories(ref IServiceCollection services)
        {
            services.AddScoped(typeof(IDbProviderRepository<>), typeof(PostgreSQLRepository<>));
            services.AddScoped<IFrameworkRepository, FrameworkRepository>();
            services.AddScoped<IProtocolRepository, ProtocolRepository>();
        }

        // CQRS
        public virtual void RegisterCQRS(ref IServiceCollection services)
        {
            // Handlers
            services.AddScoped<IGetAllFrameworksHandler, GetAllFrameworksHandler>();
            services.AddScoped<IGetByIdFrameworkHandler, GetByIdFrameworkHandler>();
            services.AddScoped<IFindFrameworksHandler, FindFrameworksHandler>();
            services.AddScoped<ICreateFrameworkHandler, CreateFrameworkHandler>();
            services.AddScoped<IUpdateFrameworkHandler, UpdateFrameworkHandler>();
            services.AddScoped<IRemoveFrameworkHandler, RemoveFrameworkHandler>();
            services.AddScoped<IGetAllProtocolsHandler, GetAllProtocolsHandler>();
            services.AddScoped<IGetByIdProtocolHandler, GetByIdProtocolHandler>();
            services.AddScoped<IFindProtocolsHandler, FindProtocolsHandler>();
            services.AddScoped<ICreateProtocolHandler, CreateProtocolHandler>();
            services.AddScoped<IUpdateProtocolHandler, UpdateProtocolHandler>();
            services.AddScoped<IRemoveProtocolHandler, RemoveProtocolHandler>();

            // Query => Handler
            services.AddScoped<IRequestHandler<BaseGetAllQuery<FrameworkGetResource>, IEnumerable<FrameworkGetResource>>, GetAllFrameworksHandler>();
            services.AddScoped<IRequestHandler<BaseGetByIdQuery<FrameworkGetResource>, FrameworkGetResource>, GetByIdFrameworkHandler>();
            services.AddScoped<IRequestHandler<BaseFindQuery<Framework, FrameworkGetResource>, IEnumerable<FrameworkGetResource>>, FindFrameworksHandler>();
            services.AddScoped<IRequestHandler<BaseGetAllQuery<ProtocolGetResource>, IEnumerable<ProtocolGetResource>>, GetAllProtocolsHandler>();
            services.AddScoped<IRequestHandler<BaseGetByIdQuery<ProtocolGetResource>, ProtocolGetResource>, GetByIdProtocolHandler>();
            services.AddScoped<IRequestHandler<BaseFindQuery<Protocol, ProtocolGetResource>, IEnumerable<ProtocolGetResource>>, FindProtocolsHandler>();

            // Command => Handler
            services.AddScoped<IRequestHandler<BaseCreateCommand<FrameworkCreateResource>, string>, CreateFrameworkHandler>();
            services.AddScoped<IRequestHandler<BaseUpdateCommand<FrameworkCreateResource>, Unit>, UpdateFrameworkHandler>();
            services.AddScoped<IRequestHandler<BaseRemoveCommand<FrameworkBaseResource>, Unit>, RemoveFrameworkHandler>();
            services.AddScoped<IRequestHandler<BaseCreateCommand<ProtocolCreateResource>, string>, CreateProtocolHandler>();
            services.AddScoped<IRequestHandler<BaseUpdateCommand<ProtocolCreateResource>, Unit>, UpdateProtocolHandler>();
            services.AddScoped<IRequestHandler<BaseRemoveCommand<ProtocolBaseResource>, Unit>, RemoveProtocolHandler>();
        }

        // SignalR
        public virtual void RegisterHubEventSenders(ref IServiceCollection services)
        {
            services.AddScoped<IEventSenderHubClient, EventSenderHubClient>();

            // Hubs
            services.AddSingleton<IFrameworkEventSenderHub, FrameworkEventSenderHub>();
            services.AddSingleton<IProtocolEventSenderHub, ProtocolEventSenderHub>();

            // Caches
            services.AddSingleton<IFrameworkEventSenderHubConnectionsCache, FrameworkEventSenderHubConnectionsCache>();
            services.AddSingleton<IProtocolEventSenderHubConnectionsCache, ProtocolEventSenderHubConnectionsCache>();
        }
    }
}
