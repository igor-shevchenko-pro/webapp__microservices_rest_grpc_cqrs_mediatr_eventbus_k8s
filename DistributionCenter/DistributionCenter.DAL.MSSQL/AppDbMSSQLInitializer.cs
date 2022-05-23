using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Helpers.EntityDbInitializeHelpers.Base;
using System;
using System.Linq;
using DistributionCenter.Core.Interfaces.Entities;
using DistributionCenter.Core.Interfaces.Entities.Base;

namespace DistributionCenter.DAL.MSSQL
{
    public class AppDbMSSQLInitializer : IAppDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<AppDbMSSQLInitializer> _logger;

        public AppDbMSSQLInitializer(IServiceScopeFactory scopeFactory, ILogger<AppDbMSSQLInitializer> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            using (var appDbContext = serviceScope.ServiceProvider.GetService<AppDbMSSQLContext>())
            {
                try
                {
                    appDbContext.Database.Migrate();

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"==> Could not run migrations: {ex.Message}" );
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            using (var appDbContext = serviceScope.ServiceProvider.GetService<AppDbMSSQLContext>())
            {
                AddEntityData<Platform>(appDbContext);
                AddEntityData<Server>(appDbContext);
            }
        }

        private void AddEntityData<T>(AppDbMSSQLContext appDbContext)
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
