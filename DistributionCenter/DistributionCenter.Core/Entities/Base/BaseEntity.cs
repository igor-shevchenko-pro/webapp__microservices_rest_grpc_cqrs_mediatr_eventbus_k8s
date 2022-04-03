using DistributionCenter.Core.Entities.Base;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributionCenter.Core.Models.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? Updated { get; set; }
        public OperationalStateStatus OperationalStateStatus { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.UtcNow;
            OperationalStateStatus = OperationalStateStatus.Active;
        }
    }
}