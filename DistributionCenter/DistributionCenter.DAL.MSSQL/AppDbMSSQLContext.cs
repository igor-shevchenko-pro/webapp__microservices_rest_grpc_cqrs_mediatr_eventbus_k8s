using Microsoft.EntityFrameworkCore;
using DistributionCenter.Core.Entities;

namespace DistributionCenter.DAL.MSSQL
{
    public class AppDbMSSQLContext : DbContext
    {
        public AppDbMSSQLContext(DbContextOptions<AppDbMSSQLContext> option)
            : base(option)
        { }

        public DbSet<Platform> Platforms => Set<Platform>();
        public DbSet<Server> Servers => Set<Server>();
    }
}
