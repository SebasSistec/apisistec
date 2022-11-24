using apisistec.Dtos.Billing;
using apisistec.Dtos.Plans;
using AutoMapper;
using Models;

namespace apisistec.Mapper
{
    public class BillingProfile : Profile
    {
        public BillingProfile()
        {
            CreateMap<CreateBillingDto, Facturascabecera>()
                .ForMember(dest => dest.CodigoFacturaCabecera,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.EmpresasFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Empleado.EmpresasEmpleado))
                .ForMember(dest => dest.NumeroFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Puntosfactura.FacturaPuntoFactura))
                .ForMember(dest => dest.TiposDocumentoFacturaCabecera,
                    opt => opt.MapFrom(o => "FV"))
                .ForMember(dest => dest.ClientesFacturaCabecera,
                    opt => opt.MapFrom(o => o.Customer.Id))
                .ForMember(dest => dest.FechaFacturaCabecera,
                    opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(dest => dest.FechaRegistroFacturaCabecera,
                    opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(dest => dest.DireccionFacturaCabecera,
                    opt => opt.MapFrom(o => o.Customer.Address))
                .ForMember(dest => dest.CaducidadFacturaCabecera,
                    opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(dest => dest.BaseIvaFacturaCabecera,
                    opt => opt.MapFrom(o => o.Payment.TotalBaseIva))
                .ForMember(dest => dest.ValorIvaFacturaCabecera,
                    opt => opt.MapFrom(o => o.Payment.TotalIvaValue))
                .ForMember(dest => dest.SubTotal0FacturaCabecera,
                    opt => opt.MapFrom(o => o.Payment.TotalBaseZero))
                .ForMember(dest => dest.SubTotalFacturaCabecera,
                    opt => opt.MapFrom(o => o.Payment.TotalBaseIva + o.Payment.TotalBaseZero))
                .ForMember(dest => dest.PorcentajeIvaFacturaCabecera,
                    opt => opt.MapFrom(o => 12)) //Get from params
                .ForMember(dest => dest.ObservacionesFacturaCabecera,
                    opt => opt.MapFrom(o => $"{DateTime.Now}, {o.Customer.FirstName} {o.Customer.LastName}, {o.Payment.Result!.Bank} - {o.Payment.Result.Card} -{o.Payment.Result.AuthCode ?? "test"}-{o.Payment.Result.BatchNo ?? "test"}- ${o.Payment.Result.Value}"))
                .ForMember(dest => dest.EmpresasFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Puntosfactura.EmpresasPuntoFactura))
                .ForMember(dest => dest.SucursalesFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Puntosfactura.SucursalesPuntoFactura))
                .ForMember(dest => dest.LocalFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Puntosfactura.LocalPuntoFactura))
                .ForMember(dest => dest.PuntoFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Puntosfactura.PuntoPuntoFactura))
                .ForMember(dest => dest.NumeroFacturaCabecera,
                    opt => opt.MapFrom(o => $"{o.Params!.Puntosfactura.FacturaPuntoFactura}".PadLeft(9, '0')))
                .ForMember(dest => dest.EmpresasFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Puntosfactura.EmpresasPuntoFactura))
                .ForMember(dest => dest.EmpleadosCreaFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Empleado.CodigoEmpleado))
                .ForMember(dest => dest.VendedoresFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Empleado.CodigoEmpleado))
                .ForMember(dest => dest.BodegasOrigenFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Bodega.CodigoBodega))
                .ForMember(dest => dest.UsuariosRegistroFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!.Empleado.NombreUsuarioEmpleado))
                .ForMember(dest => dest.NumeroFacturaCompleto,
                    opt => opt.MapFrom(o => $"{o.Params!.Puntosfactura.LocalPuntoFactura}-{o.Params!.Puntosfactura.PuntoPuntoFactura}-{o.Params!.Puntosfactura.FacturaPuntoFactura}"))
                .ForMember(dest => dest.TipoEmisionFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!
                                .Puntosfactura
                                .TipoPuntoFactura == "0"
                                ? "FISICA"
                                : o.Params!
                                .Puntosfactura
                                .TipoPuntoFactura == "1"
                                    ? "ELECTRONICA"
                                    : "MEMO"))
                .ForMember(dest => dest.TipoEmisionGuiaFacturaCabecera,
                    opt => opt.MapFrom(o => o.Params!
                                .Puntosfactura
                                .TipoPuntoFactura == "0"
                                ? "FISICA"
                                : o.Params!
                                .Puntosfactura
                                .TipoPuntoFactura == "1"
                                    ? "ELECTRONICA"
                                    : "MEMO"));

            CreateMap<PaymentResultSuccess, Facturastarjetacredito>()
                .ForMember(dest => dest.CodigoFacturaTarjetaCredito,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.NumeroTarjetaFacturaTarjetaCredito,
                    opt => opt.MapFrom(o => o.Last4Digits))
                .ForMember(dest => dest.ValorTarjetaFacturaTarjetaCredito,
                    opt => opt.MapFrom(o => o.Value))
                .ForMember(dest => dest.LoteFacturaTarjetaCredito,
                    opt => opt.MapFrom(o => o.BatchNo ?? ""))
                .ForMember(dest => dest.ReferenciaFacturaTarjetaCredito,
                    opt => opt.MapFrom(o => o.AuthCode ?? ""));

            CreateMap<Item, Facturasdetalle>()
                .ForMember(dest => dest.CodigoFacturaDetalle,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.ProductosFacturaDetalle,
                    opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.PrecioVentaFacturaDetalle,
                    opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.PrecioNegociadoFacturaDetalle,
                    opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.PrecioMarcadoFacturaDetalle,
                    opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.PrecioVentaPublicoFacturaDetalle,
                    opt => opt.MapFrom(o => o.Price))
                .ForMember(dest => dest.IvaProductoFacturaDetalle,
                    opt => opt.MapFrom(o => o.IvaValue > 0 ? 12 : 0));

            CreateMap<Facturascabecera, ContractsResponseDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.CodigoFacturaCabecera))
                .ForMember(dest => dest.InvoiceNum,
                    opt => opt.MapFrom(o => o.NumeroFacturaCabecera))
                .ForMember(dest => dest.SubtotalIva,
                    opt => opt.MapFrom(o => o.BaseIvaFacturaCabecera))
                .ForMember(dest => dest.SubtotalZero,
                    opt => opt.MapFrom(o => o.SubTotal0FacturaCabecera))
                .ForMember(dest => dest.IvaValue,
                    opt => opt.MapFrom(o => o.ValorIvaFacturaCabecera))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(o => o.FechaFacturaCabecera));
        }

    }
}
