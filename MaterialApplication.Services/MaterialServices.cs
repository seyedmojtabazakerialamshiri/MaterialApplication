using Material.Core.DTOs;
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

        public MaterialDto GetMaterialById(string id)
        {
            return _repository.GetMaterialById(id); 
        }

        public MaterialDto GetMaterialByName(string name)
        {
            return _repository.GetMaterialByName(name);
        }

        public MaterialDto CreateMaterial(MaterialDto material)
        {
            return _repository.CreateMaterial(material);
        }

        public MaterialDto UpdateMaterial(UpdateDto newMaterial)
        {
            return _repository.UpdateMaterial(newMaterial);
        }

        public MaterialDto DeleteMaterial(string id)
        {
            return _repository.DeleteMaterial(id);
        }
    }
}
