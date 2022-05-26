using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.Repositories.Base;
using CommandCenter.Core.Repositories;
using CommandCenter.DAL.Repositories.Base;

namespace CommandCenter.DAL.Repositories
{
    public class ProtocolRepository : BaseRepository<Protocol>, IProtocolRepository
    {
        public ProtocolRepository(IDbProviderGenericRepository<Protocol> repository)
            : base(repository)
        {
        }
    }
}
