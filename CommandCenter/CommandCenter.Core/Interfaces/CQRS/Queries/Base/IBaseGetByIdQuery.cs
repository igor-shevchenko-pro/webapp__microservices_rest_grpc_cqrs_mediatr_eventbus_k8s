using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;

namespace CommandCenter.Core.Interfaces.CQRS.Queries.Base
{
    public interface IBaseGetByIdQuery<TModelGet> : IRequest<TModelGet>
        where TModelGet : class, IBaseResource
    {
        string Id { get; }
    }
}
