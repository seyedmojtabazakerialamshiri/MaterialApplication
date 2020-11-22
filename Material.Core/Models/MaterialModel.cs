using System.ComponentModel.DataAnnotations;
using Material.Core.Enums;

namespace Material.Core.Models
{
    public class MaterialModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public bool Visible { get; set; }
        [Required]
        public MaterialTypeEnum.MaterialType MaterialType { get; set; }
        [Required]
        public string Notes { get; set; }
        public MaterialFunction MaterialFunction { get; set; }
    }
}
