using CommandCenter.BLL.CQRS.Handlers.Base;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.ProtocolHandlers;
using CommandCenter.Core.Interfaces.EventSenders.EventSenderManagers;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Repositories;
using CommandCenter.Core.Resources;
using Microsoft.Extensions.Logging;

namespace CommandCenter.BLL.CQRS.Handlers.ProtocolHandlers
{
    public class UpdateProtocolHandler : BaseUpdateHandler<Protocol, ProtocolCreateResource, ProtocolGetResource>, IUpdateProtocolHandler
    {
        public UpdateProtocolHandler(
            IProtocolRepository repository, 
            IDataMapper dataMapper,
            IProtocolEventSenderManager eventSenderManager,
            ILogger<UpdateProtocolHandler> logger)
            : base(repository, dataMapper, eventSenderManager, logger)
        {
        }
    }
}
