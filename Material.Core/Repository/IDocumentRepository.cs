using System.Threading.Tasks;
using Material.Core.Models;

namespace Material.Core.Repository
{
    public interface IDocumentRepository
    {
        MaterialModel CreateMaterial(MaterialModel material);
        MaterialModel GetMaterialById(string id);
        MaterialModel GetMaterialByName(string name);
        MaterialModel UpdateMaterial(MaterialModel newMaterial);
        MaterialModel DeleteMaterial(string id);

    }
}
