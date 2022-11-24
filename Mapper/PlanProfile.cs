using apisistec.Dtos.Plans;
using apisistec.Entities;
using AutoMapper;

namespace apisistec.Mapper
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<PlanHeader, PlanDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(o => o.Title))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(o => o.Description))
                .ForMember(dest => dest.StartAt,
                    opt => opt.MapFrom(o => o.StartAt))
                .ForMember(dest => dest.EndAt,
                    opt => opt.MapFrom(o => o.EndAt))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.DiscountPercent,
                    opt => opt.MapFrom(o => o.DiscountPercent))
                .ForMember(dest => dest.TransacctionQty,
                    opt => opt.MapFrom(o => o.TransacctionQty))
                .ForMember(dest => dest.RucQty,
                    opt => opt.MapFrom(o => o.RucQty))
                .ForMember(dest => dest.IvaPercent,
                    opt => opt.MapFrom(o => o.Product.PagaIvaProducto == "1" ? 12 : 0))
                .ForMember(dest => dest.ProductId,
                    opt => opt.MapFrom(o => o.Product.CodigoProducto))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(o => o.Type))
                .ForMember(dest => dest.MonthsAvailables,
                    opt => opt.MapFrom(o => o.MonthsAvailables))
                .ForMember(dest => dest.Details,
                        opt => opt.MapFrom(o => o.PlanHeaderXDetail));

            CreateMap<PlanHeaderXDetail, PlanDetailDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.Detail.Id))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(o => o.Detail.Title))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(o => o.Detail.Description))
                .ForMember(dest => dest.Order,
                    opt => opt.MapFrom(o => o.Order));
        }
    }
}
