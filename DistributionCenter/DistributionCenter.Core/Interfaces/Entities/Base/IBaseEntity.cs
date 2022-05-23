using DistributionCenter.Core.Entities.Enums;
using System;

namespace DistributionCenter.Core.Interfaces.Entities.Base
{
    public interface IBaseEntity : IIdentifiable
    {
        DateTime Created { get; }
        DateTime? Updated { get; set; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
