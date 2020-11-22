﻿using Material.Core.DTOs;

namespace Material.Core.Services
{
    public interface IMaterialServices
    {
         MaterialDto GetMaterialById(string id);
         MaterialDto GetMaterialByName(string name);
         MaterialDto CreateMaterial(MaterialDto material);
         MaterialDto UpdateMaterial(UpdateDto newMaterial);
         MaterialDto DeleteMaterial(string id);
    }
}
