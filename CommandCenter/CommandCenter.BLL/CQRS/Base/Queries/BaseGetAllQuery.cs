using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Resources.Base;

namespace CommandCenter.BLL.CQRS.Base.Queries
{
    public abstract class BaseGetAllQuery<TModelGet> : IBaseGetAllQuery<TModelGet>
        where TModelGet : class, IBaseResource
    {
    }
}
