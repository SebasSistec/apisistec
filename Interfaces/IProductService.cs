using apisistec.Dtos;
using apisistec.Dtos.Product;
using apisistec.Models.Parameters;

namespace apisistec.Interfaces
{
    public interface IProductService
    {
        PaginationDto<ProductDto> GetProducts(string companyId, QueryStringParams qParams);
    }
}
