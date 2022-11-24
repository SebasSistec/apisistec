using apisistec.Dtos.Employee;
using apisistec.Entities;
using AutoMapper;

namespace apisistec.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Empleado, EmployeeDto>()
               .ForMember(dest => dest.id,
                   opt => opt.MapFrom(o => o.CodigoEmpleado))
               .ForMember(dest => dest.identification,
                   opt => opt.MapFrom(o => o.CedulaEmpleado))
               .ForMember(dest => dest.firstName,
                   opt => opt.MapFrom(o => o.NombreEmpleado))
               .ForMember(dest => dest.lastName,
                   opt => opt.MapFrom(o => o.ApellidoEmpleado))
               .ForMember(dest => dest.email,
                   opt => opt.MapFrom(o => o.EmailEmpleado));
        }
    }
}
