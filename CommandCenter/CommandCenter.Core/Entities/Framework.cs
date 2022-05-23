using CommandCenter.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandCenter.Core.Entities
{
    public class Framework : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Version { get; set; } = string.Empty;

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
