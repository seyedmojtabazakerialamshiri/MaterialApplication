using System;
using Material.Core.DTOs;
using Material.Core.Enums;

namespace Material.Core.Helper
{
    public static class HelperMethods
    {
        public static String GetId(this string val)
        {
            return val.Replace(@"%2F", "/");
        }

        public static Models.MaterialModel MapProp(this Models.MaterialModel material, UpdateDto newMaterial)
        {
            material.Author = newMaterial.Author;
            material.MaterialType = (MaterialTypeEnum.MaterialType)Enum.Parse(typeof(MaterialTypeEnum.MaterialType), newMaterial.MaterialType); 
            material.Name = newMaterial.Name;
            material.Notes = newMaterial.Notes;
            material.Visible = newMaterial.Visible;
            material.MaterialFunction.MaxTemp = newMaterial.MaterialFunction.MaxTemp;
            material.MaterialFunction.MinTemp = newMaterial.MaterialFunction.MinTemp;
            return material;
        }
    }
}
