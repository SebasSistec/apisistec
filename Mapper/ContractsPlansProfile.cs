using apisistec.Dtos.Plans;
using apisistec.Entities;
using AutoMapper;

namespace apisistec.Mapper
{
    public class ContractsPlansProfile : Profile
    {
        public ContractsPlansProfile()
        {
            CreateMap<ContractedPlans, ContractsResponseDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.SubtotalZero,
                    opt => opt.MapFrom(o => o.SubtotalZero))
                .ForMember(dest => dest.SubtotalIva,
                    opt => opt.MapFrom(o => o.SubtotalIva))
                .ForMember(dest => dest.IvaValue,
                    opt => opt.MapFrom(o => o.IvaValue))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(o => o.CreatedAt))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(o => o.Plan.Title))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(o => o.Plan.Description))
                .ForMember(dest => dest.EDocsCount,
                    opt => opt.MapFrom(o => o.EDocsCount))
                .ForMember(dest => dest.InvoiceNum,
                    opt => opt.MapFrom(o => $"{o.Billing.LocalFacturaCabecera}-{o.Billing.PuntoFacturaCabecera}-{o.Billing.NumeroFacturaCabecera}"));
        }
    }
}
