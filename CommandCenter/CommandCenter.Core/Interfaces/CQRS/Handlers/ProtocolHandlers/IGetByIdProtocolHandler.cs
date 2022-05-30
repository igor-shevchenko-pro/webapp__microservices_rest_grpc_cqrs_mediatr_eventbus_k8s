using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.CQRS.Handlers.Base;
using CommandCenter.Core.Resources;

namespace CommandCenter.Core.Interfaces.CQRS.Handlers.ProtocolHandlers
{
    public interface IGetByIdProtocolHandler : IBaseGetByIdHandler<Protocol, ProtocolGetResource>
    {
    }
}
