using AutoMapper;
using Material.Core.DTOs;
using Material.Core.Models;

namespace Material.API.Api
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Mapping rules
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<MaterialDto, MaterialModel>()
                .ForMember(a => a.MaterialType, opt => opt.MapFrom(c => c.MaterialType.ToString()));
            CreateMap<MaterialModel, MaterialDto>()
                .ForMember(a => a.MaterialType, opt => opt.MapFrom(c => c.MaterialType.ToString()));
            CreateMap<MaterialModel, UpdateDto>()
                .ForMember(a => a.MaterialType, opt => opt.MapFrom(c => c.MaterialType.ToString()))
                .ForMember(a => a.Id, opt => opt.MapFrom(c => c.Id.ToString()));
            CreateMap<MaterialDto, UpdateDto>()
                .ForMember(a => a.MaterialType, opt => opt.MapFrom(c => c.MaterialType.ToString()));
            CreateMap<UpdateDto, MaterialModel>()
                .ForMember(a => a.MaterialType, opt => opt.MapFrom(c => c.MaterialType.ToString()));
            CreateMap<UpdateDto, MaterialDto>()
                .ForMember(a => a.MaterialType, opt => opt.MapFrom(c => c.MaterialType.ToString()));
        }
    }
}
