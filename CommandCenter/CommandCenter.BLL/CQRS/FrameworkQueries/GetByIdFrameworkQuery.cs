using CommandCenter.BLL.CQRS.Base.Queries;
using CommandCenter.Core.Interfaces.CQRS.Queries.FrameworkQueries;
using CommandCenter.Core.Resources;

namespace CommandCenter.BLL.CQRS.FrameworkQueries
{
    public class GetByIdFrameworkQuery : BaseGetByIdQuery<FrameworkGetResource>, IGetByIdFrameworkQuery
    {
        public GetByIdFrameworkQuery(string id)
            : base(id)
        {
        }
    }
}
