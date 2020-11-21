using System.Threading.Tasks;
using Material.Core.Models;

namespace Material.Core.Services
{
    public interface IMaterialServices
    {
         MaterialModel GetMaterialById(string id);
         MaterialModel GetMaterialByName(string name);
         MaterialModel CreateMaterial(MaterialModel material);
         MaterialModel UpdateMaterial(MaterialModel newMaterial);
         MaterialModel DeleteMaterial(string id);
    }
}
