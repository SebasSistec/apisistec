using apisistec.Dtos.Product;
using apisistec.Entities;
using AutoMapper;
using Models;

namespace apisistec.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<EmpresasProductos, ProductDto>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => o.Product.CodigoProducto))
                .ForMember(dest => dest.code,
                    opt => opt.MapFrom(o => o.Product.CodigoVentaProducto))
                .ForMember(dest => dest.description,
                    opt => opt.MapFrom(o => o.Product.DescripcionProducto))
                .ForMember(dest => dest.price,
                    opt => opt.MapFrom(o => o.PrecioVentaProducto));
        }
    }
}
