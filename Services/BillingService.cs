using apisistec.Context;
using apisistec.Dtos.Billing;
using apisistec.Entities;
using apisistec.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apisistec.Services
{
    public class BillingService : IBillingService
    {
        private DataContext _context;
        private IMapper _mapper;

        public BillingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BillingParams GetBillingParams() => _context.BillingParams
                                                    .Include(x => x.Bodega)
                                                    .Include(x => x.Puntosfactura)
                                                    .Include(x => x.Empleado)
                                                    .Include(x => x.Producto)
                                                    .FirstOrDefault()!;

        public void Billing(BillingDto billData, string clientId, out Facturascabecera billingSaved)
        {
            CreateBillingDto createBilling = new()
            {
                Customer = billData.Customer,
                Items = billData.Items,
                Payment = billData.Payment,
                Params = GetBillingParams()
            };

            billData.Customer.Id = clientId;
            Facturascabecera billing = _mapper.Map<Facturascabecera>(createBilling);
            Facturastarjetacredito billingCard = _mapper.Map<Facturastarjetacredito>(billData.Payment.Result);
            billingCard.FacturasCabeceraFacturaTarjetaCredito = billing.CodigoFacturaCabecera;
            List<Facturasdetalle> billingDetails = _mapper.Map<List<Facturasdetalle>>(billData.Items);
            var plan = _context.PlanHeader.Select(x => new
            {
                x.Id,
                description = $"{x.Title} {x.Description}"
            }).FirstOrDefault(x => x.Id == billData.PlanId);

            billingDetails.ForEach(detail =>
            {
                var product = _context.Productos.Select(x => new
                {
                    Codigo = x.CodigoProducto,
                    Descripcion = x.DescripcionProducto,
                    CuentasContabilidadVentaProducto = x.CuentasContabilidadVentaProducto,
                    CuentasContabilidadCompraProducto = x.CuentasContabilidadCompraProducto,
                    CuentasContabilidadCostoProducto = x.CuentasContabilidadCostoProducto
                }).FirstOrDefault(x => x.Codigo == detail.ProductosFacturaDetalle)!;

                detail.FacturasCabeceraFacturaDetalle = billing.CodigoFacturaCabecera;
                detail.EmpresasFacturaDetalle = billing.EmpresasFacturaCabecera;
                detail.SucursalesFacturaDetalle = billing.SucursalesFacturaCabecera;
                detail.LocalFacturaDetalle = billing.LocalFacturaCabecera;
                detail.PuntoFacturaDetalle = billing.PuntoFacturaCabecera;
                detail.NumeroCabeceraFacturaDetalle = billing.NumeroFacturaCabecera;
                detail.TiposDocumentoFacturaDetalle = billing.TiposDocumentoFacturaCabecera;
                detail.FechaFacturaDetalle = billing.FechaFacturaCabecera;
                detail.EmpleadosCreaFacturaDetalle = billing.EmpleadosCreaFacturaCabecera;
                detail.VendedoresFacturaDetalle = billing.VendedoresFacturaCabecera;
                detail.BodegasOrigenFacturaDetalle = billing.BodegasOrigenFacturaCabecera;
                detail.CuentasVentaFacturaDetalle = product.CuentasContabilidadVentaProducto;
                detail.CuentasCompraFacturaDetalle = product.CuentasContabilidadCompraProducto;
                detail.CuentasCostoFacturaDetalle = product.CuentasContabilidadCostoProducto;
                detail.UsuariosFacturaDetalle = billing.UsuariosRegistroFacturaCabecera;
                detail.DescripcionProductoFacturaDetalle = $"{product.Descripcion}: {plan?.description ?? billData.PlanId.ToString()}";
            });

            Facturaspago BillingPayment = new Facturaspago
            {
                FacturasCabeceraFacturaPago = billing.CodigoFacturaCabecera,
                TarjetaFacturaPago = billData.Payment.Result!.Value
            };

            createBilling.Params.Puntosfactura.FacturaPuntoFactura += 1;

            _context.FacturasTarjetaCredito.Add(billingCard);
            _context.FacturasCabeceras.Add(billing);
            _context.FacturaPagos.Add(BillingPayment);
            _context.FacturaDetalles.AddRange(billingDetails);
            _context.PuntosFactura.Update(createBilling.Params.Puntosfactura);
            billingSaved = billing;
        }
    }
}
