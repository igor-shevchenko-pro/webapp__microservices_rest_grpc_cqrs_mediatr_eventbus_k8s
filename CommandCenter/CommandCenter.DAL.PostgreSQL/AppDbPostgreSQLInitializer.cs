using CommandCenter.Core.Entities;
using CommandCenter.Core.Helpers.EntityDbInitializeHelpers.Base;
using CommandCenter.Core.Interfaces.Entities;
using CommandCenter.Core.Interfaces.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CommandCenter.DAL.PostgreSQL
{
    public class AppDbPostgreSQLInitializer : IAppDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<AppDbPostgreSQLInitializer> _logger;

        public AppDbPostgreSQLInitializer(IServiceScopeFactory scopeFactory, ILogger<AppDbPostgreSQLInitializer> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            using (var appDbContext = serviceScope.ServiceProvider.GetService<AppDbPostgreSQLContext>())
            {
                try
                {
                    appDbContext.Database.Migrate();

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"==> Could not run migrations: {ex.Message}");
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            using (var appDbContext = serviceScope.ServiceProvider.GetService<AppDbPostgreSQLContext>())
            {
                AddEntityData<Framework>(appDbContext);
                AddEntityData<Protocol>(appDbContext);
            }
        }

        private void AddEntityData<T>(AppDbPostgreSQLContext appDbContext)
            where T : class, IBaseEntity, new()
        {
            var dbTable = appDbContext.Set<T>();

            foreach (var item in BaseDbInitializeHelper.Current.GetItems<T>())
            {
                if (dbTable.Any(x => x.Id.Equals(item.Id)) == false)
                {
                    dbTable.Add(item);
                }
            }

            appDbContext.SaveChanges();
        }
    }
}
