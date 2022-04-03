using DistributionCenter.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Core.Entities
{
    public class Platform : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        public string Cost { get; set; } = string.Empty;
    }
}