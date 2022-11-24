using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class FacturasCabeceraConfiguration : IEntityTypeConfiguration<Facturascabecera>
    {
        public void Configure(EntityTypeBuilder<Facturascabecera> entity)
        {
            entity.HasKey(e => e.CodigoFacturaCabecera).HasName("PRIMARY");

            entity.ToTable("facturascabecera", x => x.ExcludeFromMigrations());

            entity.HasIndex(e => e.AnuladoFacturaCabecera, "AnuladoFacturaCabecera");

            entity.HasIndex(e => new { e.EmpresasFacturaCabecera, e.AsientosCabeceraFacturaCabecera }, "AsientoEmpresa");

            entity.HasIndex(e => e.ClientesFacturaCabecera, "Clientes");

            entity.HasIndex(e => e.CodigoFacturaCabecera, "CodigoFacturaCabecera").IsUnique();

            entity.HasIndex(e => e.ContratoCabeceraFacturaCabecera, "ContratoCabecera");

            entity.HasIndex(e => e.VendedoresFacturaCabecera, "EmpleadoSolicita");

            entity.HasIndex(e => e.EmpleadosCreaFacturaCabecera, "Empleados");

            entity.HasIndex(e => e.EmpresasFacturaCabecera, "Empresas");

            entity.HasIndex(e => e.EstadoElectronicoFacturaCabecera, "EstadoElectronicoFacturaCabecera");

            entity.HasIndex(e => e.EstadoElectronicoGuiaFacturaCabecera, "EstadoElectronicoGuiaFacturaCabecera");

            entity.HasIndex(e => e.FechaFacturaCabecera, "Fecha");

            entity.HasIndex(e => e.IdTransaccionFacturaCabecera, "IdTransaccion");

            entity.HasIndex(e => e.LocalFacturaCabecera, "LocalFacturaCabecera");

            entity.HasIndex(e => e.LocalesClienteFacturaCabecera, "LocalesCliente");

            entity.HasIndex(e => e.NumeroAutorizacionElectronicoFacturaCabecera, "NumeroAutorizacionElectronicoFacturaCabecera");

            entity.HasIndex(e => e.NumeroFacturaCabecera, "NumeroFacturaCabecera");

            entity.HasIndex(e => new { e.LocalFacturaCabecera, e.PuntoFacturaCabecera, e.NumeroFacturaCabecera }, "NumeroFacturaCompleto");

            entity.HasIndex(e => e.NumeroGuiaFacturaCabecera, "NumeroGuiaFacturaCabecera");

            entity.HasIndex(e => e.PuntoFacturaCabecera, "PuntoFacturaCabecera");

            entity.HasIndex(e => e.TiposDocumentoFacturaCabecera, "TipoDocumento");

            entity.HasIndex(e => e.TipoEmisionFacturaCabecera, "TipoEmisionFacturaCabecera");

            entity.HasIndex(e => e.TiposPagoFacturaCabecera, "TiposPago");

            entity.HasIndex(e => new { e.AnuladoFacturaCabecera, e.TipoEmisionFacturaCabecera, e.EstadoElectronicoFacturaCabecera, e.NumeroAutorizacionElectronicoFacturaCabecera, e.EmpresasFacturaCabecera, e.NumeroFacturaCabecera }, "ValidarElectronico");

            entity.HasIndex(e => e.SucursalesFacturaCabecera, "sucursal");

            entity.Property(e => e.CodigoFacturaCabecera).HasMaxLength(36).HasDefaultValueSql("''");

            entity.Property(e => e.AnuladoFacturaCabecera).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.AplicoPromocionFacturaCabecera).HasMaxLength(5).HasDefaultValueSql("''").HasComment("Indica si se aplico la promocion en la factura");

            entity.Property(e => e.AsientosCabeceraFacturaCabecera).HasPrecision(10);

            entity.Property(e => e.AutorizacionFacturaCabecera).HasMaxLength(10).HasDefaultValueSql("'0000000000'");

            entity.Property(e => e.BaseIvaFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.BodegasOrigenFacturaCabecera).HasMaxLength(20);

            entity.Property(e => e.BonoAplicadoFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.BonoGeneradoFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.CaducidadFacturaCabecera).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.CarpetaAnuladoFacturaCabecera).HasColumnType("int(5)");

            entity.Property(e => e.ChequesProtestadoFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.ClaveAccesoFacturaCabecera).HasMaxLength(50).HasDefaultValueSql("'00000000000000000000000000000000000000000000000000'").HasComment("clave de acceso generada por el sistema wise");

            entity.Property(e => e.ClaveAccesoGuiaFacturaCabecera).HasMaxLength(50).HasDefaultValueSql("'00000000000000000000000000000000000000000000000000'");

            entity.Property(e => e.ClientesFacturaCabecera).HasMaxLength(36).HasDefaultValueSql("''");

            entity.Property(e => e.ContratoCabeceraFacturaCabecera).HasMaxLength(20);

            entity.Property(e => e.CuentasEfectivoFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.DireccionFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.DireccionGuiaFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.EmpleadosCreaFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.EmpresasFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.EstadoElectronicoFacturaCabecera).HasMaxLength(40).HasDefaultValueSql("'FISICA'");

            entity.Property(e => e.EstadoElectronicoGuiaFacturaCabecera).HasMaxLength(40).HasDefaultValueSql("'FISICA'");

            entity.Property(e => e.EstadoSincronizadoFacturaCabecera).HasColumnType("int(1)");

            entity.Property(e => e.FacturaEnviadaFacturaCabecera).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.FechaAnulacionFacturaCabecera).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'");

            entity.Property(e => e.FechaAutorizacionElectronicoFacturaCabecera).HasMaxLength(30).HasDefaultValueSql("'000000000000000000000000000000'").IsFixedLength();

            entity.Property(e => e.FechaAutorizacionGuiaElectronicoFacturaCabecera).HasMaxLength(30).HasDefaultValueSql("'000000000000000000000000000000'").IsFixedLength();

            entity.Property(e => e.FechaFacturaCabecera).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaImpresionFacturaCabecera).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'");

            entity.Property(e => e.FechaRegistroFacturaCabecera).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'");

            entity.Property(e => e.IdTransaccionFacturaCabecera).HasMaxLength(22).HasColumnName("idTransaccionFacturaCabecera");

            entity.Property(e => e.ImpresionFacturaCabecera).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.IpAnulaFacturaCabecera).HasMaxLength(20);

            entity.Property(e => e.ListasPrecioFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.LocalFacturaCabecera).HasMaxLength(3).HasDefaultValueSql("'000'");

            entity.Property(e => e.LocalGuiaFacturaCabecera).HasMaxLength(3).HasDefaultValueSql("'000'");

            entity.Property(e => e.LocalesClienteFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.MotivosFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.NumeroAutorizacionElectronicoFacturaCabecera).HasMaxLength(50).HasDefaultValueSql("'0000000000000000000000000000000000000'");

            entity.Property(e => e.NumeroAutorizacionGuiaElectronicoFacturaCabecera).HasMaxLength(50).HasDefaultValueSql("'0000000000000000000000000000000000000'");

            entity.Property(e => e.NumeroFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.NumeroGuiaFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Almacena el numero de guia de envio de mercaderia");

            entity.Property(e => e.NumeroOrdenCompraFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.NumeroTurnoFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.ObservacionGuiaFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.ObservacionOmitirComisionFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.ObservacionesAnulacionFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.ObservacionesAutorizadoFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.ObservacionesClienteFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.ObservacionesFacturaCabecera).HasColumnType("text");

            entity.Property(e => e.OmitirComisionFacturaCabecera).HasColumnType("int(1)");

            entity.Property(e => e.OmitirDinardapFacturaCabecera).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.OtroImpuestoFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.PlacaTransporteFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.PorcentajeDescuento0FacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.PorcentajeDescuentoFacturaCabecera).HasPrecision(7, 4);

            entity.Property(e => e.PorcentajeIceFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.PorcentajeIvaFacturaCabecera).HasPrecision(7, 4);

            entity.Property(e => e.PorcentajeServicioFacturaCabecera).HasPrecision(5, 2);

            entity.Property(e => e.PorcentajeTransporte0FacturaCabecera).HasPrecision(7, 4);

            entity.Property(e => e.PorcentajeTransporteFacturaCabecera).HasPrecision(7, 4);

            entity.Property(e => e.PuntoFacturaCabecera).HasMaxLength(3).HasDefaultValueSql("'000'");

            entity.Property(e => e.PuntoGuiaFacturaCabecera).HasMaxLength(3).HasDefaultValueSql("'000'");

            entity.Property(e => e.RutasDespachoFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.ServicioTecnicoFacturaCabecera).HasMaxLength(2).HasDefaultValueSql("'0'");

            entity.Property(e => e.SubTotal0FacturaCabecera).HasPrecision(12, 4);

            entity.Property(e => e.SubTotalFacturaCabecera).HasPrecision(12, 4);

            entity.Property(e => e.SubTotalIceFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.SucursalesFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.TipoEmisionFacturaCabecera).HasMaxLength(12).HasDefaultValueSql("'FISICA'");

            entity.Property(e => e.TipoEmisionGuiaFacturaCabecera).HasMaxLength(12).HasDefaultValueSql("'FISICA'");

            entity.Property(e => e.TiposDocumentoFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.TiposPagoFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.TiposPagoSriFacturaCabecera).HasMaxLength(20);

            entity.Property(e => e.TransportistasFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Alamcena el transpotista");

            entity.Property(e => e.UsuariosAnuloFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.UsuariosImpresionFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.UsuariosRegistroFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.ValorDescuento0FacturaCabecera).HasColumnType("double(16,4)");

            entity.Property(e => e.ValorDescuentoFacturaCabecera).HasPrecision(12, 4);

            entity.Property(e => e.ValorDescuentoItems0FacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorDescuentoItemsFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorDescuentoItemsGrabaFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorIceFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorIvaFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorServicioFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorTransporte0FacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.ValorTransporteFacturaCabecera).HasPrecision(16, 4);

            entity.Property(e => e.VendedoresFacturaCabecera).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.VentaActivoFacturaCabecera).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.VentaReembolsoFacturaCabecera).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.NumeroFacturaCompleto).HasMaxLength(36).HasDefaultValueSql("''");
        }
    }
}
