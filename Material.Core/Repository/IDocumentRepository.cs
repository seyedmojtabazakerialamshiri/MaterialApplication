using System.Threading.Tasks;
using Material.Core.DTOs;
using Material.Core.Models;

namespace Material.Core.Repository
{
    public interface IDocumentRepository
    {
        MaterialDto CreateMaterial(MaterialDto material);
        MaterialDto GetMaterialById(string id);
        MaterialDto GetMaterialByName(string name);
        MaterialDto UpdateMaterial(UpdateDto newMaterial);
        MaterialDto DeleteMaterial(string id);

    }
}
