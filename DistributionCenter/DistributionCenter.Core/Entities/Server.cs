using DistributionCenter.Core.Entities.Enums;
using DistributionCenter.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Core.Entities
{
    public  class Server : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public ServerType Type { get; set; }
    }
}
