using CommandCenter.Core.Interfaces.Resources.Base;
using MediatR;
using System.Collections.Generic;

namespace CommandCenter.Core.Interfaces.CQRS.Queries.Base
{
    public interface IGetAllResourcesBaseQuery<TModelGet> : IRequest<IEnumerable<TModelGet>>
        where TModelGet : class, IBaseResource
    {
    }
}
