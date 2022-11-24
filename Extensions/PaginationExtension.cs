using apisistec.Dtos;
using apisistec.Models.Parameters;

namespace apisistec.Extensions
{
    public static class PaginationExtension
    {
        public static PaginationDto<T> GetPaged<T>(this IEnumerable<T> list, QueryStringParams qParams)
        {
            double totalPages = (double)list.Count() / qParams.pageSize;
            return new()
            {
                currentPage = qParams.page,
                pageSize = qParams.pageSize,
                total = list.Count(),
                totalPages = (int)Math.Ceiling(totalPages),
                result = list.Skip((qParams.page - 1) * qParams.pageSize).Take(qParams.pageSize)
            };
        }
    }
}
