using CommandCenter.Core.Interfaces.CQRS.Queries.Base;
using CommandCenter.Core.Resources;

namespace CommandCenter.Core.Interfaces.CQRS.Queries.FrameworkQueries
{
    public interface IGetAllFrameworksQuery : IBaseGetAllQuery<FrameworkGetResource>
    {
    }
}
