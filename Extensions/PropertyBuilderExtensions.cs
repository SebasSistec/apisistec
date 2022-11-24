
using apisistec.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Extensions
{
    public static class PropertyBuilderExtensions
    {
        /// <summary>
        ///     Configures a comment to be applied to the column based on enum value, auto generated
        /// </summary>
        /// <typeparam name="TProperty"> The type of the property being configured. </typeparam>
        /// <param name="propertyBuilder"> The builder for the property being configured. </param>
        /// <param name="comment"> The comment for the column. </param>
        /// <returns> The same builder instance so that multiple calls can be chained. </returns>
        public static PropertyBuilder<TProperty> HasEnumComment<TProperty>(
            this PropertyBuilder<TProperty> propertyBuilder)
            where TProperty : Enum
        {
            return propertyBuilder.HasComment(EnumHelper.GetEnumValuesJoin<TProperty>());
        }
    }
}
