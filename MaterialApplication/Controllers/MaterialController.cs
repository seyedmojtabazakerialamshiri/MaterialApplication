using System.Threading.Tasks;
using Material.API.Api;
using Material.Core.Api;
using Material.Core.DTOs;
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
        public async Task<ApiResult<MaterialDto>> CreateMaterial([FromBody] MaterialDto material)
        {
            var mat = _materialService.CreateMaterial(material);
            if (mat == null) return await Task.FromResult<ApiResult<MaterialDto>>(BadRequest("The material exist. Please enter a new material."));
            return Ok(mat);
        }

        /// <summary>
        /// Get material by id
        /// </summary>
        /// <param name="id">return material info</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ApiResult<MaterialDto>> GetMaterialById(string id)
        {
            var material =  _materialService.GetMaterialById(id);
            if (material == null) return await Task.FromResult<ApiResult<MaterialDto>>(NotFound());
            return material;
        }

        /// <summary>
        /// Get material by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>return material info</returns>
        [HttpGet]
        [Route("")]
        public async Task<ApiResult<MaterialDto>> GetMaterialByName([FromQuery(Name = "name")] string name)
        {
            var material =  _materialService.GetMaterialByName(name);
            if (material == null) return await Task.FromResult<ApiResult<MaterialDto>>(NotFound());
            return material;
        }

        /// <summary>
        /// Update material info
        /// </summary>
        /// <param name="newMaterial"></param>
        /// <returns>Return updated material</returns>
        [HttpPut]
        [Route("")]
        public async Task<ApiResult<MaterialDto>> UpdateMaterial([FromBody] UpdateDto newMaterial)
        {
            var material =  _materialService.UpdateMaterial(newMaterial);
            if (material == null) return await Task.FromResult<ApiResult<MaterialDto>>(NotFound());
            return Ok(material);
        }

        /// <summary>
        /// Delete material by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ApiResult<MaterialDto>> DeleteMaterial(string id)
        {
            var material =  _materialService.DeleteMaterial(id);
            if (material == null) return await Task.FromResult<ApiResult<MaterialDto>>(NotFound());
            return Ok(material);
        }

    }
}
