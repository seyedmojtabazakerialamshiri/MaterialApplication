using System.ComponentModel.DataAnnotations;
using Material.Core.Models;

namespace Material.Core.DTOs
{
    public class MaterialDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public bool Visible { get; set; }
        [Required]
        public string MaterialType { get; set; }
        [Required]
        public string Notes { get; set; }
        public MaterialFunction MaterialFunction { get; set; }
    }
}
