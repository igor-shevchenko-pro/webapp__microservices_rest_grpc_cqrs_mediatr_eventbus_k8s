using DistributionCenter.Core.Entities.Base;
using System;

namespace DistributionCenter.Core.Interfaces.Repositories.Base
{
    public interface IBaseEntity : IIdentifiable
    {
        DateTime Created { get; }
        DateTime? Updated { get; set; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
