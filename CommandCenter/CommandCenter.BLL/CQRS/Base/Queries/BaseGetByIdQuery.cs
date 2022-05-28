using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Resources.Base;

namespace CommandCenter.BLL.CQRS.Base.Queries
{
    public abstract class BaseGetByIdQuery<TModelGet> : IBaseGetByIdQuery<TModelGet>
        where TModelGet : class, IBaseResource
    {
        public string Id { get; }

        public BaseGetByIdQuery(string id)
        {
            Id = id;
        }
    }
}
