using DistributionCenter.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Core.Entities
{
    public class Platform : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Version { get; set; } = string.Empty;

        [Required]
        public double FileSize { get; set; }
    }
}