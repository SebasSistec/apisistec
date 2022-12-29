using apisistec.Dtos;
using apisistec.Models.Parameters;

namespace apisistec.Extensions
{
    public static class PaginationExtension
    {
        public static PaginationDto<T> GetPaged<T>(this IEnumerable<T> list, QueryParams qParams)
        {
            double totalPages = (double)list.Count() / qParams.pageSize;
            IEnumerable<T> data = list.Skip((qParams.page - 1) * qParams.pageSize).Take(qParams.pageSize);
            bool isValid = data.Count() > 0 && list.Count() > 0;
            return new()
            {
                currentPage = isValid ? qParams.page : 1,
                pageSize = qParams.pageSize,
                total = list.Count(),
                totalPages = (int)Math.Ceiling(totalPages),
                data = isValid ? data : list.Skip(0 * qParams.pageSize).Take(qParams.pageSize)
        };
        }
    }
}
