using AutoMapper;
using System.Linq.Expressions;
using System.Reflection;

namespace apisistec.Extensions
{
    public static class IQueryableExtenssion
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
                          bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            Type type = typeof(TEntity);
            PropertyInfo property = type.GetProperty(orderByProperty)!;
            ParameterExpression parameter = Expression.Parameter(type, "p");
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
