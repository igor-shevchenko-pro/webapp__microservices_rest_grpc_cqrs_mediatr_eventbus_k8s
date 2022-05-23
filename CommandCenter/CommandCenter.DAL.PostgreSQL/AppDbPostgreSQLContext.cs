using CommandCenter.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommandCenter.DAL.PostgreSQL
{
    public class AppDbPostgreSQLContext : DbContext
    {
        public AppDbPostgreSQLContext(DbContextOptions<AppDbPostgreSQLContext> option)
            : base(option)
        { }

        public DbSet<Framework> Platforms => Set<Framework>();
    }
}
