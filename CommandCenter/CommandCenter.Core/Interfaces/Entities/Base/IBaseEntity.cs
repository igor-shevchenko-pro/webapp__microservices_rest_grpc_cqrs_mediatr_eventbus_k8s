using CommandCenter.Core.Entities.Enums;
using System;

namespace CommandCenter.Core.Interfaces.Entities.Base
{
    public interface IBaseEntity : IIdentifiable
    {
        DateTime Created { get; }
        DateTime? Updated { get; set; }
        OperationalStateStatus OperationalStateStatus { get; set; }
    }
}
