using System.Threading.Tasks;
using Material.API.Api;
using Material.Core.Api;
using Material.Core.Helper;
using Material.Core.Models;
using Material.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Material.API.Controllers
{
    /// <summary>
    /// Material Controller
    /// </summary>
    [ApiController]
    [ApiResultFilter]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {

        private readonly IMaterialServices _materialService;

        /// <summary>
        /// MaterialController Constructor
        /// </summary>
        /// <param name="materialService"></param>
        public MaterialController(IMaterialServices materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// Add new material to database
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ApiResult<MaterialModel>> CreateMaterial([FromBody] MaterialModel material)
        {
            var mat = _materialService.CreateMaterial(material);
            return Ok(mat);
        }

        /// <summary>
        /// Get material by id
        /// </summary>
        /// <param name="id">return material info</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ApiResult<MaterialModel>> GetMaterialById(string id)
        {
            var material =  _materialService.GetMaterialById(id.GetId());
            if (material == null) return NotFound();
            return material;
        }

        /// <summary>
        /// Get material by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>return material info</returns>
        [HttpGet]
        [Route("")]
        public async Task<ApiResult<MaterialModel>> GetMaterialByName([FromQuery(Name = "name")] string name)
        {
            var material =  _materialService.GetMaterialByName(name);
            if (material == null) return NotFound();
            return material;
        }

        /// <summary>
        /// Update material info
        /// </summary>
        /// <param name="newMaterial"></param>
        /// <returns>Return updated material</returns>
        [HttpPut]
        [Route("")]
        public async Task<ApiResult<MaterialModel>> UpdateMaterial([FromBody] MaterialModel newMaterial)
        {
            var material =  _materialService.UpdateMaterial(newMaterial);
            return Ok(material);
        }

        /// <summary>
        /// Delete material by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ApiResult<MaterialModel>> DeleteMaterial(string id)
        {
            var material =  _materialService.DeleteMaterial(id);
            return Ok(material);
        }

    }
}
