using System;

namespace Material.Core.Helper
{
    public static class HelperMethods
    {
        public static String GetId(this string val)
        {
            return val.Replace(@"%2F", "/");
        }

        public static Models.MaterialModel MapProp(this Models.MaterialModel material, Models.MaterialModel newMaterial)
        {
            material.Author = newMaterial.Author;
            material.MaterialType = newMaterial.MaterialType;
            material.Name = newMaterial.Name;
            material.Notes = newMaterial.Notes;
            material.Visible = newMaterial.Visible;
            material.MaterialFunction.MaxTemp = newMaterial.MaterialFunction.MaxTemp;
            material.MaterialFunction.MinTemp = newMaterial.MaterialFunction.MinTemp;
            return material;
        }
    }
}
