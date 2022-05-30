using CommandCenter.BLL.CQRS.Handlers.Base;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.ProtocolHandlers;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Repositories;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.CQRS.Handlers.ProtocolHandlers
{
    public class RemoveProtocolHandler : BaseRemoveHandler<Protocol, ProtocolBaseResource>, IRemoveProtocolHandler
    {
        public RemoveProtocolHandler(IProtocolRepository repository, IDataMapper dataMapper, ILogger<RemoveProtocolHandler> logger)
            : base(repository, dataMapper, logger)
        {
        }
    }
}
