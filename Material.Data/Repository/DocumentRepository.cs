using System.Linq;
using System.Threading.Tasks;
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

        public DocumentRepository(IOptions<RavenSettings> ravenSettings)
        {
            var settings = ravenSettings.Value;
            var store = new DocumentStore {Urls = new[] {settings.Url}, Database = settings.DefaultDatabase};
            DataContext = store.Initialize() as DocumentStore;
        }

        public MaterialModel CreateMaterial(MaterialModel material)
        {
            using (var session = DataContext.OpenSession())
            {
                session.Store(material);
                session.SaveChanges();

                return material;
            }
        }

        public MaterialModel GetMaterialById(string id)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Load<MaterialModel>(id);

                return material;
            }
        }

        public MaterialModel GetMaterialByName(string name)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Query<MaterialModel>().FirstOrDefault(a=> a.Name == name);

                return material;
            }
        }

        public MaterialModel UpdateMaterial(MaterialModel newMaterial)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Load<MaterialModel>(newMaterial.Id).MapProp(newMaterial);
                session.Store(material);
                session.SaveChanges();
                return material;
            }
        }

        public MaterialModel DeleteMaterial(string id)
        {
            using (var session = DataContext.OpenSession())
            {
                var material = session.Load<MaterialModel>(id);
                session.Delete(material);
                session.SaveChanges();
                return material;
            }
        }


    }
}
