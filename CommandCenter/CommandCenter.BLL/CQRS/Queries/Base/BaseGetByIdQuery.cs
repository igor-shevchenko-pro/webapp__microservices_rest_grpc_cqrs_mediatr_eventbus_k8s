using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Interfaces.Resources.Base;

namespace CommandCenter.BLL.CQRS.Queries.Base
{
    public class BaseGetByIdQuery<TModelGet> : IBaseGetByIdQuery<TModelGet>
        where TModelGet : class, IBaseResource
    {
        public string Id { get; }

        public BaseGetByIdQuery(string id)
        {
            Id = id;
        }
    }
}
