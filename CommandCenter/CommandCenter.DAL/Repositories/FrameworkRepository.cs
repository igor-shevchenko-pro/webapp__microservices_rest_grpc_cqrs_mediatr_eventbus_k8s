using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.Repositories;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.DAL.Repositories.Base;

namespace CommandCenter.DAL.Repositories
{
    public class FrameworkRepository : BaseRepository<Framework>, IFrameworkRepository
    {
        public FrameworkRepository(IDbProviderRepository<Framework> repository)
            : base(repository)
        {
        }
    }
}
