using System.ComponentModel.DataAnnotations;
using Material.Core.DTOs;

namespace Material.Core.Validation
{
    class TemperatureAttribute : ValidationAttribute
    {
        public TemperatureAttribute(float min,float max)
        {
            Min = min;
            Max = max;
        }

        public float Max { get; }
        public float Min { get; }

        public string GetErrorMessage() =>
            $"Material temperature should be between {Min} and {Max}";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (validationContext.ObjectType.FullName != null && validationContext.ObjectType.FullName.Contains("UpdateDto"))
            {
                var material = (UpdateDto)validationContext.ObjectInstance;
                if (material.MaterialFunction == null) return ValidationResult.Success;
                if (material.MaterialFunction.MinTemp < 4 || material.MaterialFunction.MaxTemp > 80)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                var minResult = material.MaterialFunction.MinTemp / (float)0.1;
                var minrounded = (int)minResult;
                if (minResult - minrounded != 0)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                var maxResult = material.MaterialFunction.MaxTemp / (float)0.1;
                var maxrounded = (int)maxResult;
                if (maxResult - maxrounded != 0)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                return ValidationResult.Success;
            }
            else if (validationContext.ObjectType.FullName.Contains("MaterialDto"))
            {
                var material = validationContext.ObjectInstance as MaterialDto;
                if (material.MaterialFunction == null) return ValidationResult.Success;
                if (material.MaterialFunction.MinTemp < 4 || material.MaterialFunction.MaxTemp > 80)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                var minResult = material.MaterialFunction.MinTemp / (float)0.1;
                var minrounded = (int)minResult;
                if (minResult - minrounded != 0)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                var maxResult = material.MaterialFunction.MaxTemp / (float)0.1;
                var maxrounded = (int)maxResult;
                if (maxResult - maxrounded != 0)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                return ValidationResult.Success;
            }

            return ValidationResult.Success;

        }
    }
}
