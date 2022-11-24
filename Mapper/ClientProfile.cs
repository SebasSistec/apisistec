using apisistec.Dtos.Billing;
using apisistec.Dtos.Client;
using apisistec.Entities;
using AutoMapper;

namespace apisistec.Mapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CustomerDto, Cliente>()
                .ForMember(dest => dest.CodigoCliente,
                    opt => opt.MapFrom(o => Guid.NewGuid().ToString().Substring(0, 20)))
                .ForMember(dest => dest.NumeroIdentificacionCliente,
                    opt => opt.MapFrom(o => o.Identification))
                .ForMember(dest => dest.TiposIdentificacionCliente,
                    opt => opt.MapFrom(o => o.IdentificationType))
                .ForMember(dest => dest.NombreCliente,
                    opt => opt.MapFrom(o => o.FirstName))
                .ForMember(dest => dest.ApellidoCliente,
                    opt => opt.MapFrom(o => o.LastName))
                .ForMember(dest => dest.NombreComercialCliente,
                    opt => opt.MapFrom(o => o.CompanyName))
                .ForMember(dest => dest.DireccionUnoCliente,
                    opt => opt.MapFrom(o => o.Address))
                .ForMember(dest => dest.MailCliente,
                    opt => opt.MapFrom(o => o.Email))
                .ForMember(dest => dest.TelefonoUnoCliente,
                    opt => opt.MapFrom(o => o.Phone))
                .ForMember(dest => dest.PrioridadNombreComercialCliente,
                    opt => opt.MapFrom(o => o.PriorityTradeName ? "1" : "0"))
                .ForMember(dest => dest.NombreCompleto,
                    opt => opt.MapFrom(o => $"{o.CompanyName} {o.FirstName} {o.LastName}"))
                .ForMember(dest => dest.FechaRegistro,
                    opt => opt.MapFrom(o => DateTime.Now));

            CreateMap<Cliente, ClientDto>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(o => o.CodigoCliente))
                .ForMember(dest => dest.identification,
                    opt => opt.MapFrom(o => o.NumeroIdentificacionCliente))
                .ForMember(dest => dest.completeName,
                    opt => opt.MapFrom(o => $"{o.NombreCliente} {o.ApellidoCliente}"))
                .ForMember(dest => dest.tradeName,
                    opt => opt.MapFrom(o => o.NombreComercialCliente))
                .ForMember(dest => dest.email,
                    opt => opt.MapFrom(o => o.MailCliente))
                .ForMember(dest => dest.address,
                    opt => opt.MapFrom(o => o.DireccionUnoCliente));
        }
    }
}
