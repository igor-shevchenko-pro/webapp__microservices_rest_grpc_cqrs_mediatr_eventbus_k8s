using CommandCenter.BLL.CQRS.Base.Queries;
using CommandCenter.Core.Interfaces.CQRS.Queries.FrameworkQueries;
using CommandCenter.Core.Resources;

namespace CommandCenter.BLL.CQRS.FrameworkQueries
{
    public class GetAllFrameworksQuery : GetAllResourcesBaseQuery<FrameworkGetResource>, IGetAllFrameworksQuery
    {
    }
}
