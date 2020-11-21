using System;

namespace Material.Core.Enums
{
    public static class MaterialTypeEnum
    {
        public enum MaterialType
        {
            Continuous = 1,
            Dispersed = 2
        }

        public static String ToString(this MaterialType outputFormat)
        {
            var result = "";
            switch (outputFormat)
            {
                case MaterialType.Continuous:
                    result = "continuous(liquid)";
                    break;
                case MaterialType.Dispersed:
                    result = "dispersed(particles)";
                    break;
            }

            return result;
        }

        public static MaterialType ToEnum(this string enumValue)
        {
            if (Enum.TryParse(enumValue, true, out MaterialType outputFormat)) return outputFormat;
            if (enumValue.Equals(ToString(MaterialType.Continuous), StringComparison.InvariantCultureIgnoreCase))
                outputFormat = MaterialType.Continuous;
            else if (enumValue.Equals(ToString(MaterialType.Dispersed), StringComparison.InvariantCultureIgnoreCase))
                outputFormat = MaterialType.Dispersed;
            else
                throw new InvalidCastException($"'{enumValue}' is not a valid");

            return outputFormat;
        }
    }

}
