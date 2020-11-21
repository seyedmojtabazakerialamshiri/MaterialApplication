using Material.Core.Validation;

namespace Material.Core.Models
{
    [Temperature(4,80)]
    public class MaterialFunction
    {
        public float MaxTemp { get; set; }
        public float MinTemp { get; set; }
    }
}
