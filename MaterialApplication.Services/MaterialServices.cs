using System.Threading.Tasks;
using Material.Core.Models;
using Material.Core.Repository;
using Material.Core.Services;

namespace Material.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IDocumentRepository _repository;

        public MaterialServices(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public MaterialModel GetMaterialById(string id)
        {
            return _repository.GetMaterialById(id); 
        }

        public MaterialModel GetMaterialByName(string name)
        {
            return _repository.GetMaterialByName(name);
        }

        public MaterialModel CreateMaterial(MaterialModel material)
        {
            return _repository.CreateMaterial(material);
        }

        public MaterialModel UpdateMaterial(Core.Models.MaterialModel newMaterial)
        {
            return _repository.UpdateMaterial(newMaterial);
        }

        public MaterialModel DeleteMaterial(string id)
        {
            return _repository.DeleteMaterial(id);
        }
    }
}
