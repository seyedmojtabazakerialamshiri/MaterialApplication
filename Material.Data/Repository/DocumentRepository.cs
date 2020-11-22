using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Material.Core.DTOs;
using Material.Core.Helper;
using Material.Core.Models;
using Material.Core.Repository;
using Material.Data.Configs;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;


namespace Material.Data.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        protected DocumentStore DataContext { get; set; }
        protected readonly IMapper Mapper;

        public DocumentRepository(IOptions<RavenSettings> ravenSettings,IMapper mapper)
        {
            Mapper = mapper;
            var settings = ravenSettings.Value;
            var store = new DocumentStore {Urls = new[] {settings.Url}, Database = settings.DefaultDatabase};
            store.Conventions.RegisterAsyncIdConvention<MaterialModel>((a, material) => Task.FromResult(GetId()));
            DataContext = store.Initialize() as DocumentStore;
        }

        public MaterialDto CreateMaterial(MaterialDto material)
        {
            using (var session = DataContext.OpenSession())
            {
                var mat = session.Query<MaterialModel>().Count(a => a.Name == material.Name);
                if (mat > 0) return null;
                var entityMaterialModel = Mapper.Map<MaterialModel>(material);
                session.Store(entityMaterialModel);
                session.SaveChanges();
                return material;

            }
        }

        public MaterialDto GetMaterialById(string id)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Load<MaterialModel>(id);
                if (material == null) return null;
                var materialDto = Mapper.Map<MaterialDto>(material);
                return materialDto;
            }
        }

        public MaterialDto GetMaterialByName(string name)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Query<MaterialModel>().FirstOrDefault(a=> a.Name == name);
                if (material == null) return null;
                var materialDto = Mapper.Map<MaterialDto>(material);
                return materialDto;
            }
        }

        public MaterialDto UpdateMaterial(UpdateDto newMaterial)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Load<MaterialModel>(newMaterial.Id);
                if (material == null) return null;
                material.MapProp(newMaterial);
                session.Store(material);
                session.SaveChanges();
                var matDto = Mapper.Map<MaterialDto>(newMaterial);
                return matDto;
            }
        }

        public MaterialDto DeleteMaterial(string id)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Load<MaterialDto>(id);
                if (material == null) return null;
                session.Delete(material);
                session.SaveChanges();
                return material;
            }
        }

        private string GetId()
        {
            using (var session = DataContext.OpenSession())
            {
                var id = session.Query<MaterialModel>().OrderByDescending(a => a.Id).Select(a=>a.Id).FirstOrDefault();
                return id == null ? "1" : (int.Parse(id) + 1).ToString();
            }
        }


    }
}
