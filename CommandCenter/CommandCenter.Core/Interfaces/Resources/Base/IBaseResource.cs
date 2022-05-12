using CommandCenter.Core.Entities.Enums;
using System;

namespace CommandCenter.Core.Interfaces.Resources.Base
{
    public interface IBaseResource
    {
        string? Id { get; }
        DateTime? Created { get; }
        DateTime? Updated { get; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
