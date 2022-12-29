using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Product;
using apisistec.Entities;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using apisistec.Extensions;

namespace apisistec.Services
{
    public class ProductService : IProductService
    {
        private DataContext _context;
        private IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PaginationDto<ProductDto> GetProducts(string companyId, QueryParams qParams)
        {
            IEnumerable<EmpresasProductos> product = _context.EmpresasProductos
                    .Include(x => x.Product)
                    .OrderBy(x => x.Product.DescripcionProducto)
                    .Where(x => x.EmpresasEmpresaProducto.Equals(companyId))
                    .ToList();

            if (!string.IsNullOrEmpty(qParams.search))
                product = product.Where(x => x.Product.DescripcionProducto.ToLower().Contains(qParams.search)
                    || x.Product.CodigoVentaProducto.ToLower().Contains(qParams.search)
                );

            if (qParams.isOrderByDescending == true)
                product = product.OrderByDescending(x => x.Product.DescripcionProducto);

            IEnumerable<ProductDto> mapped = _mapper.Map<IEnumerable<ProductDto>>(product);
            PaginationDto<ProductDto> paged = mapped.GetPaged(qParams);
            return paged;
        }
    }
}
