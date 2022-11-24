using System.ComponentModel;

namespace apisistec.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumValue)
            where T : Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static IEnumerable<T> GetEnumValues<T>()
            where T : Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            return Enum
                    .GetValues(typeof(T))
                    .Cast<T>();
        }

        public static string GetEnumValuesJoin<T>()
            where T : Enum
        {
            if (!typeof(T).IsEnum)
                return null;

            return string.Join(", ", GetEnumValues<T>()
                                        .Select(e => $"{Convert.ToInt32(e)}: {e.GetDescription()}")
                                        );
        }
    }
}
