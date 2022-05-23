using CommandCenter.Core.Resources;
using MediatR;
using System.Collections.Generic;

namespace CommandCenter.BLL.Services.CQRS.Framework.Queries
{
    public class GetFrameworksQuery : IRequest<IEnumerable<FrameworkGetResource>>
    {
    }
}
