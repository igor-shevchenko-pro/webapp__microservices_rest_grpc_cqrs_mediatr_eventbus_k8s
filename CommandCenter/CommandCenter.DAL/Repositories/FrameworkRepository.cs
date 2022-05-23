using CommandCenter.Core.Entities;
using CommandCenter.Core.Repositories;
using CommandCenter.Core.Repositories.Base;
using CommandCenter.DAL.Repositories.Base;

namespace CommandCenter.DAL.Repositories
{
    public class FrameworkRepository : BaseRepository<Framework>, IFrameworkRepository
    {
        public FrameworkRepository(IDbProviderGenericRepository<Framework> repository)
            : base(repository)
        {
        }
    }
}
