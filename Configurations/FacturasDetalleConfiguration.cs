using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class FacturasDetalleConfiguration : IEntityTypeConfiguration<Facturasdetalle>
    {
        public void Configure(EntityTypeBuilder<Facturasdetalle> entity)
        {
            entity.HasKey(e => e.CodigoFacturaDetalle).HasName("PRIMARY");

            entity.ToTable("facturasdetalle", x => x.ExcludeFromMigrations());

            entity.HasIndex(e => e.CodigoFacturaDetalle, "CodigoFacturaDetalle").IsUnique();

            entity.HasIndex(e => e.TiposDocumentoFacturaDetalle, "FK_TipoDocumento");

            entity.HasIndex(e => e.BodegasOrigenFacturaDetalle, "Index_Bodegas");

            entity.HasIndex(e => e.FacturasCabeceraFacturaDetalle, "Index_DocAfecta");

            entity.HasIndex(e => e.EmpresasFacturaDetalle, "Index_Empresas");

            entity.HasIndex(e => e.FechaFacturaDetalle, "Index_Fecha");

            entity.HasIndex(e => e.OrdenesPedidoDetalleFacturaDetalle, "Index_OrdenesPedidoDetalleFacturaDetalle");

            entity.HasIndex(e => e.ProductosFacturaDetalle, "Index_Productos");

            entity.HasIndex(e => e.SucursalesFacturaDetalle, "Index_Sucursales");

            entity.HasIndex(e => e.UsuariosFacturaDetalle, "Index_Usuarios");

            entity.Property(e => e.CodigoFacturaDetalle).HasMaxLength(36).HasDefaultValueSql("''");

            entity.Property(e => e.BodegasOrigenFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.BonificacionFacturaDetalle).HasPrecision(16, 4);

            entity.Property(e => e.CantidadFacturaDetalle).HasPrecision(10, 4);

            entity.Property(e => e.CodigoPadreFacturaDetalle).HasMaxLength(36).HasDefaultValueSql("''");

            entity.Property(e => e.CodigosComboFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.ComboProductoFacturaDetalle).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.CostoIsdproductoFacturaDetalle).HasPrecision(16, 4).HasColumnName("CostoISDProductoFacturaDetalle");

            entity.Property(e => e.CostoProductoFacturaDetalle).HasPrecision(16, 6);

            entity.Property(e => e.CuentasCompraFacturaDetalle).HasMaxLength(18).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasCostoFacturaDetalle).HasMaxLength(18).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasVentaFacturaDetalle).HasMaxLength(18).HasDefaultValueSql("''");

            entity.Property(e => e.DescripcionProductoFacturaDetalle).HasMaxLength(255).HasDefaultValueSql("''");

            entity.Property(e => e.DescuentoFacturaDetalle).HasPrecision(16, 6);

            entity.Property(e => e.EmpleadosCreaFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.EmpresasFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.FechaAnulacionFacturaDetalle).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'");

            entity.Property(e => e.FechaFacturaDetalle).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaRegistroFacturaDetalle).HasColumnType("datetime").HasDefaultValueSql("'1900-01-01 00:00:00'");

            entity.Property(e => e.GrupoProductoFacturaDetalle).HasColumnType("int(3)");

            entity.Property(e => e.IvaProductoFacturaDetalle).HasPrecision(5, 2);

            entity.Property(e => e.LocalFacturaDetalle).HasMaxLength(3).HasDefaultValueSql("'000'");

            entity.Property(e => e.NumeroCabeceraFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.ObservacionFacturaDetalle).HasColumnType("text");

            entity.Property(e => e.OrdenesPedidoDetalleFacturaDetalle).HasMaxLength(36).HasDefaultValueSql("''");

            entity.Property(e => e.PorcentajeDescuentoAdicionalFacturaDetalle).HasPrecision(16, 4);

            entity.Property(e => e.PorcentajeDescuentoFacturaDetalle).HasPrecision(16, 6);

            entity.Property(e => e.PorcentajeDescuentoPvpfacturaDetalle).HasPrecision(16, 4).HasColumnName("PorcentajeDescuentoPVPFacturaDetalle");

            entity.Property(e => e.PosicionFacturaDetalle).HasColumnType("int(4)");

            entity.Property(e => e.PrecioMarcadoFacturaDetalle).HasPrecision(16, 4);

            entity.Property(e => e.PrecioNegociadoFacturaDetalle).HasPrecision(16, 6);

            entity.Property(e => e.PrecioVentaFacturaDetalle).HasPrecision(16, 6);

            entity.Property(e => e.PrecioVentaPublicoFacturaDetalle).HasPrecision(16, 4);

            entity.Property(e => e.ProcentajeIceFacturaDetalle).HasPrecision(5, 2);

            entity.Property(e => e.ProductoDadoDeBaja).HasColumnType("int(1)");

            entity.Property(e => e.ProductosFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.PromocionAplicaFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.PromocionFacturaDetalle).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.PuntoFacturaDetalle).HasMaxLength(3).HasDefaultValueSql("'000'");

            entity.Property(e => e.SucursalesFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.TipoIcesFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.TipoProductoFacturaDetalle).HasMaxLength(1).HasDefaultValueSql("'N'");

            entity.Property(e => e.TiposDocumentoFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.UsuariosFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.VendedoresFacturaDetalle).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.FacturasCabeceraFacturaDetalle).HasMaxLength(36).HasDefaultValueSql("''");

            entity.HasOne(x => x.Billing)
                .WithMany(x => x.BillingDetails)
                .HasForeignKey(x => x.FacturasCabeceraFacturaDetalle)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
