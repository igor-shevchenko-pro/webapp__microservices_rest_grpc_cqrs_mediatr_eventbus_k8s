using DistributionCenter.Core.Entities.Base;
using System;

namespace DistributionCenter.Core.Interfaces.Resources.Base
{
    public interface IBaseResource
    {
        string? Id { get; }
        DateTime? Created { get; }
        DateTime? Updated { get; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
