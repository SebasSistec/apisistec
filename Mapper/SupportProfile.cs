using apisistec.Dtos.File;
using apisistec.Dtos.Product;
using apisistec.Dtos.Project;
using apisistec.Dtos.Support;
using apisistec.Entities;
using AutoMapper;
using Models;

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
                    opt => opt.MapFrom(o => o.clientId))
                .ForMember(dest => dest.projectId,
                    opt => opt.MapFrom(o => o.projectId));

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
                    opt => opt.MapFrom(o => o.product.id))
                .ForMember(dest => dest.moduleId,
                    opt => opt.MapFrom(o => o.moduleId));

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

            CreateMap<IssueTimings, IssueTimingDto>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => o.id))
                .ForMember(dest => dest.state,
                    opt => opt.MapFrom(o => o.state))
                .ForMember(dest => dest.startAt,
                    opt => opt.MapFrom(o => o.startAt))
                .ForMember(dest => dest.endAt,
                    opt => opt.MapFrom(o => o.endAt))
                .ForMember(dest => dest.pauseDescription,
                    opt => opt.MapFrom(o => o.pauseDescription))
                .ForMember(dest => dest.createdAt,
                    opt => opt.MapFrom(o => o.createdAt));

            CreateMap<Issues, SupportDto>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => o.id))
                .ForMember(dest => dest.orderNumber,
                    opt => opt.MapFrom(o => o.orderNumber))
                .ForMember(dest => dest.state,
                    opt => opt.MapFrom(o => o.state))
                .ForMember(dest => dest.priority,
                    opt => opt.MapFrom(o => o.priority))
                .ForMember(dest => dest.createdAt,
                    opt => opt.MapFrom(o => o.createdAt))
                .ForMember(dest => dest.client,
                    opt => opt.MapFrom(o => o.client))
                .ForMember(dest => dest.details,
                    opt => opt.MapFrom(o => o.issueDetails));

            CreateMap<IssueDetails, SupportDetailDto>()
               .ForMember(dest => dest.id,
                   opt => opt.MapFrom(o => o.id))
               .ForMember(dest => dest.title,
                   opt => opt.MapFrom(o => o.title))
               .ForMember(dest => dest.description,
                   opt => opt.MapFrom(o => o.description))
               .ForMember(dest => dest.estimatedHours,
                   opt => opt.MapFrom(o => o.estimatedHours))
               .ForMember(dest => dest.createdAt,
                   opt => opt.MapFrom(o => o.createdAt))
               .ForMember(dest => dest.files,
                   opt => opt.MapFrom(o => o.files))
               .ForMember(dest => dest.module,
                   opt => opt.MapFrom(o => o.module))
               .ForMember(dest => dest.product,
                   opt => opt.MapFrom(o => o.producto))
               .ForMember(dest => dest.timing,
                   opt => opt.MapFrom(o => o.timings[0]));

            CreateMap<IssueFiles, FileResponseDto>()
              .ForMember(dest => dest.id,
                  opt => opt.MapFrom(o => o.id))
              .ForMember(dest => dest.path,
                  opt => opt.MapFrom(o => o.path))
              .ForMember(dest => dest.name,
                  opt => opt.MapFrom(o => o.name))
              .ForMember(dest => dest.extension,
                  opt => opt.MapFrom(o => o.extension));

            CreateMap<Projects, ProjectOrModuleDto>()
              .ForMember(dest => dest.Name,
                  opt => opt.MapFrom(o => o.name))
              .ForMember(dest => dest.Description,
                  opt => opt.MapFrom(o => o.description));

            CreateMap<Modules, ProjectOrModuleDto>()
              .ForMember(dest => dest.Name,
                  opt => opt.MapFrom(o => o.name))
              .ForMember(dest => dest.Description,
                  opt => opt.MapFrom(o => o.description));

            CreateMap<Producto, ProductDto>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => o.CodigoProducto))
                .ForMember(dest => dest.code,
                    opt => opt.MapFrom(o => o.CodigoVentaProducto))
                .ForMember(dest => dest.description,
                    opt => opt.MapFrom(o => o.DescripcionProducto));
        }
    }
}
