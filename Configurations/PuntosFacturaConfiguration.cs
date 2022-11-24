using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class PuntosFacturaConfiguration : IEntityTypeConfiguration<Puntosfactura>
    {
        public void Configure(EntityTypeBuilder<Puntosfactura> entity)
        {
            entity.HasKey(e => e.CodigoPuntoFactura).HasName("PRIMARY");

            entity.ToTable("puntosfacturas", x => x.ExcludeFromMigrations());

            entity.HasComment("PuntosFacura");

            entity.HasIndex(e => e.CuentaChequePuntoFactura, "FK_CuentaChequePuntoFactura");

            entity.HasIndex(e => e.CuentaCreditoPuntoFactura, "FK_CuentaCreditoPuntoFactura");

            entity.HasIndex(e => e.CuentaCreditoRelacionadosPuntoFactura, "FK_CuentaCreditoRelacionadosPuntoFactura");

            entity.HasIndex(e => e.CuentaEfectivoPuntoFactura, "FK_CuentaEfectivoPuntoFactura");

            entity.HasIndex(e => e.CuentaTarjetaCreditoPuntoFactura, "FK_CuentaTarjetaCreditoPuntoFactura");

            entity.HasIndex(e => e.SucursalesPuntoFactura, "FK_puntosfacturas_Sucursales");

            entity.HasIndex(e => new { e.EmpresasPuntoFactura, e.LocalPuntoFactura, e.PuntoPuntoFactura }, "Index_PuntoFactura").IsUnique();

            entity.Property(e => e.CodigoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo Punto Factura;text;true;false;Datos;180;left");

            entity.Property(e => e.AgregarProductosEnBloqueBuscador).HasColumnType("int(1)");

            entity.Property(e => e.AutorizacionFacturaPunto).HasMaxLength(10).HasDefaultValueSql("'0'");

            entity.Property(e => e.AutorizacionFacturaPuntoFactura).HasMaxLength(50).HasComment("Autorizacion Factura;text;true;true;Datos;180;left");

            entity.Property(e => e.AutorizacionLiquidacionPuntoFactura).HasMaxLength(10).HasComment("Autorizacion Liquidacion de Compra;text;true;true;Datos;180;left");

            entity.Property(e => e.AutorizacionNotaCreditoPuntoFactura).HasMaxLength(10).HasComment("Autorizacion Nota de Credito;text;true;true;Datos;180;left");

            entity.Property(e => e.AutorizacionNotaVentaPuntoFactura).HasMaxLength(10).HasComment("Autorizacion Nota de Venta ;text;true;true;Datos;180;left");

            entity.Property(e => e.AutorizacionRetencionPuntoFactura).HasMaxLength(10).HasComment("Autorizacion Retencion;text;true;true;Datos;180;left");

            entity.Property(e => e.BodegaDefectoPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.BodegaOrigenSolicitudTransferenciaServicioTecnicoPuntoFactura).HasMaxLength(30).HasDefaultValueSql("''");

            entity.Property(e => e.CaducidadFacturaPuntoFactura).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'").HasComment("Caducidad Factura;cal;true;true;Datos;180;left");

            entity.Property(e => e.CaducidadLiquidacionPuntoFactura).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'").HasComment("Caducidad Liquidacion de Compra;cal;true;true;Datos;180;left");

            entity.Property(e => e.CaducidadNotaCreditoPuntoFactura).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'").HasComment("Caducidad Nota de Credito;cal;true;true;Datos;180;left");

            entity.Property(e => e.CaducidadNotaVentaPuntoFactura).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'").HasComment("Caducidad Nota de Venta;cal;true;true;Datos;180;left");

            entity.Property(e => e.CaducidadRetencionPuntoFactura).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'").HasComment("Caducidad Retencion;cal;true;true;Datos;180;left");

            entity.Property(e => e.CajeroRecargasPuntoFactura).HasMaxLength(10).HasDefaultValueSql("'5555'");

            entity.Property(e => e.ChequeGarantiaActualPuntoFactura).HasColumnType("bigint(20)").HasDefaultValueSql("'1'");

            entity.Property(e => e.ChequeProtestadoPuntoFactura).HasColumnType("double(16,0)");

            entity.Property(e => e.ClaveRecargasPuntoFactura).HasMaxLength(10).HasDefaultValueSql("'5555'");

            entity.Property(e => e.CompraActualPuntoFactura).HasColumnType("bigint(1)").HasDefaultValueSql("'1'");

            entity.Property(e => e.CuentaChequePuntoFactura).HasMaxLength(20);

            entity.Property(e => e.CuentaContableDescuadrePuntoFactura).HasMaxLength(20);

            entity.Property(e => e.CuentaCreditoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'1.01.02.001.001'");

            entity.Property(e => e.CuentaCreditoRelacionadosPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.CuentaEfectivoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'1.01.01.001.017'");

            entity.Property(e => e.CuentaTarjetaCreditoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'1.01.01.001.003'");

            entity.Property(e => e.DefectoRetencionPuntoFactura).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.DepositoBancoPuntoFactura).HasColumnType("double(16,4)");

            entity.Property(e => e.DireccionItinerantePuntoFactura).HasMaxLength(150).HasDefaultValueSql("''");

            entity.Property(e => e.DisponibleFacturacionBloquePuntoFactura).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.EmisonChequePuntoFactura).HasColumnType("double(16,4)");

            entity.Property(e => e.EmpresasPuntoFactura).HasMaxLength(20).HasComment("Empresa;combo;true;false;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas");

            entity.Property(e => e.EsPuntoServicioTecnicoPuntoFactura).HasColumnType("int(1)").HasDefaultValueSql("'1'");

            entity.Property(e => e.FactoringPuntoFactura).HasColumnType("double(16,0)");

            entity.Property(e => e.FacturaPuntoFactura).HasColumnType("bigint(11)").HasComment("Factura Actual;text;true;true;Datos;180;left");

            entity.Property(e => e.FacturaUsuarioAperturaCajaPuntoFactura).HasColumnType("int(1)");

            entity.Property(e => e.FechaGuiaPuntoFactura).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.GenerarGuiaPuntoFactura).HasMaxLength(1);

            entity.Property(e => e.HabilitadoPuntoFactura).HasColumnType("int(1)").HasDefaultValueSql("'1'");

            entity.Property(e => e.HabilitadoServicioRecargasPuntoFactura).HasColumnType("int(1)");

            entity.Property(e => e.ItinerantePuntoFactura).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.LiquidacionPuntoFactura).HasColumnType("bigint(11)").HasComment("Liquidacion de Compra Actual;text;true;true;Datos;180;left");

            entity.Property(e => e.LocalPuntoFactura).HasMaxLength(3).HasComment("Local Factura;text;true;true;Datos;180;left");

            entity.Property(e => e.ModelosImpresionFacturaPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'Default'");

            entity.Property(e => e.ModelosImpresionGuiaRemisionPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'DefaultGuiaRemision'");

            entity.Property(e => e.ModelosImpresionNotaCreditoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'DefaultNotaCredito'");

            entity.Property(e => e.ModelosImpresionPagoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'DefaultPago'");

            entity.Property(e => e.ModelosImpresionRetencionPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'DefaultRetencion'");

            entity.Property(e => e.NegociablePuntoFactura).HasColumnType("int(1)");

            entity.Property(e => e.NotaCreditoPuntoFactura).HasColumnType("bigint(11)").HasComment("Nota de Credito Actual;text;true;true;Datos;180;left");

            entity.Property(e => e.NotaVentaPuntoFactura).HasColumnType("bigint(11)").HasComment("Nota de Venta Actual;text;true;true;Datos;180;left");

            entity.Property(e => e.NumeroAjusteInventarioPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroAnticipoProveedorPuntoFactura).HasColumnType("double(16,4)").HasDefaultValueSql("'1.0000'");

            entity.Property(e => e.NumeroCuentaImportacionPuntoFactura).HasColumnType("double(16,4)");

            entity.Property(e => e.NumeroDepositoBancoCaja).HasColumnType("int(10)").HasDefaultValueSql("'1'");

            entity.Property(e => e.NumeroDespiecePuntoFactura).HasColumnType("bigint(11)");

            entity.Property(e => e.NumeroFacturaFinPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.NumeroFacturaInicioPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.NumeroGuiaFinPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroGuiaInicioPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroGuiaPuntoFactura).HasColumnType("bigint(11)");

            entity.Property(e => e.NumeroMovimientoBancoPuntoFactura).HasColumnType("int(16)").HasDefaultValueSql("'1'");

            entity.Property(e => e.NumeroNotaCreditoFinPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroNotaCreditoInicioPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroPagoClientePuntoFactura).HasColumnType("double(16,0)").HasDefaultValueSql("'1'");

            entity.Property(e => e.NumeroPagoProveedorPuntoFactura).HasColumnType("double(16,4)");

            entity.Property(e => e.NumeroPagoPuntoFactura).HasColumnType("double(16,0)");

            entity.Property(e => e.NumeroRetencionFinPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroRetencionInicioPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.NumeroRetencionPuntoFactura).HasColumnType("double(16,4)").HasDefaultValueSql("'1.0000'");

            entity.Property(e => e.NumeroTransferenciaImportacionPuntoFactura).HasColumnType("int(10)").HasDefaultValueSql("'1'");

            entity.Property(e => e.NumuroGuiaInternaPuntoFactura).HasColumnType("bigint(11)");

            entity.Property(e => e.OrdenCompraPuntoFactura).HasColumnType("double(16,0)").HasDefaultValueSql("'1'").HasComment("Caducidad Retencion;cal;false;false;Datos;180;left");

            entity.Property(e => e.OrdenGastoPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'1'");

            entity.Property(e => e.OrdenImportacionPuntoFactura).HasColumnType("double(16,0)").HasDefaultValueSql("'1'").HasComment("Caducidad Retencion;cal;false;false;Datos;180;left");

            entity.Property(e => e.OrdenPedidoPuntoFactura).HasColumnType("double(16,0)").HasDefaultValueSql("'1'").HasComment("Caducidad Retencion;cal;false;false;Datos;180;left");

            entity.Property(e => e.OrdenProduccionPuntoFactura).HasColumnType("bigint(11)");

            entity.Property(e => e.OrdenServicioTecnicoPuntoFactura).HasColumnType("double(16,0)").HasDefaultValueSql("'1'").HasComment("Caducidad Retencion;cal;false;false;Datos;180;left");

            entity.Property(e => e.OrdenVentaPuntoFactura).HasColumnType("double(16,0)").HasDefaultValueSql("'1'").HasComment("Caducidad Retencion;cal;false;false;Datos;180;left");

            entity.Property(e => e.PerfilesDocsPendientesPuntoFactura).HasMaxLength(20);

            entity.Property(e => e.PrefijoItinerantePuntoFactura).HasMaxLength(100).HasDefaultValueSql("'FERIA'");

            entity.Property(e => e.PuntoPuntoFactura).HasMaxLength(3).HasComment("Punto Factura;text;true;true;Datos;180;left");

            entity.Property(e => e.RealizarImpresionPuntoFactura).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.RealizarSeguimientoPuntoFactura).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.RetencionPuntoFactura).HasColumnType("bigint(11)").HasComment("Retencion Actual;text;true;true;Datos;180;left");

            entity.Property(e => e.SecuenciaAnticiposClientesPuntoFactura).HasColumnType("int(10)").HasDefaultValueSql("'1'");

            entity.Property(e => e.SecuenciaAtorizacionRecargasPuntoFactura).HasColumnType("int(6)");

            entity.Property(e => e.SecuenciaDespachosPuntoFactura).HasColumnType("int(10)").HasDefaultValueSql("'1'");

            entity.Property(e => e.SecuenciaNotaCreditoCompraPuntoFactura).HasColumnType("bigint(1)");

            entity.Property(e => e.SecuenciaNotaCreditoGastoPuntoFactura).HasColumnType("bigint(1)");

            entity.Property(e => e.SecuenciaNotaCreditoImportacionPuntoFactura).HasColumnType("bigint(1)");

            entity.Property(e => e.SecuenciaOrdenServicioTecnicoPuntoFactura).HasColumnType("int(10)");

            entity.Property(e => e.SecuenciaReferenciaRecargasPuntoFactura).HasColumnType("int(6)");

            entity.Property(e => e.SeleccionaVendedorPuntoFactura).HasColumnType("int(1)").HasDefaultValueSql("'1'");

            entity.Property(e => e.ServicioLaboratorioPuntoFactura).HasColumnType("double(16,0)");

            entity.Property(e => e.SucursalesPuntoFactura).HasMaxLength(20).HasComment("Sucursal;combo;true;false;Datos;180;left;Select CodigoSucursal,NombreSucursal from Sucursales");

            entity.Property(e => e.TidRecargasPuntoFactura).HasMaxLength(20).HasDefaultValueSql("'10957975'");

            entity.Property(e => e.TipoPuntoFactura).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.UsuariosPuntoFactura).HasMaxLength(20);

        }
    }
}
