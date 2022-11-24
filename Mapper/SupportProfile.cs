using apisistec.Dtos.Support;
using apisistec.Entities;
using AutoMapper;

namespace apisistec.Mapper
{
    public class SupportProfile : Profile
    {
        public SupportProfile()
        {
            CreateMap<IssueCreateDto, Issues>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.asignedToId,
                    opt => opt.MapFrom(o => o.asignToId))
                .ForMember(dest => dest.priority,
                    opt => opt.MapFrom(o => o.priority))
                .ForMember(dest => dest.clientId,
                    opt => opt.MapFrom(o => o.clientId));

            CreateMap<IssueDetailDto, IssueDetails>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.title,
                    opt => opt.MapFrom(o => o.title))
                .ForMember(dest => dest.description,
                    opt => opt.MapFrom(o => o.description))
                .ForMember(dest => dest.estimatedHours,
                    opt => opt.MapFrom(o => o.estimatedHours))
                .ForMember(dest => dest.employeeId,
                    opt => opt.MapFrom(o => o.employee.id))
                .ForMember(dest => dest.productId,
                    opt => opt.MapFrom(o => o.product.id));

            CreateMap<IssueDetails, IssueTimings>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.issueDetailId,
                    opt => opt.MapFrom(o => o.id));

            CreateMap<IssueTimingDto, IssueTimings>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.state,
                    opt => opt.MapFrom(o => o.state))
                .ForMember(dest => dest.startAt,
                    opt => opt.MapFrom(o => o.startAt))
                .ForMember(dest => dest.endAt,
                    opt => opt.MapFrom(o => o.endAt))
                .ForMember(dest => dest.pauseDescription,
                    opt => opt.MapFrom(o => o.pauseDescription));

            //CreateMap<IssueDetails, IssueTimings>()
            //    .ForMember(dest => dest.id,
            //        opt => opt.MapFrom(o => Guid.NewGuid()))
            //    .ForMember(dest => dest.issueDetailId,
            //        opt => opt.MapFrom(o => o.id));

        }
    }
}
