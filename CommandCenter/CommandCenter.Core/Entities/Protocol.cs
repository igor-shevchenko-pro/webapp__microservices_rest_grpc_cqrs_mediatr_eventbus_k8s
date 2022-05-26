using CommandCenter.Core.Entities.Base;
using CommandCenter.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CommandCenter.Core.Entities
{
    public class Protocol : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public ProtocolType Type { get; set; }
    }
}
