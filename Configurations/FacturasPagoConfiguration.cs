using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class FacturasPagoConfiguration : IEntityTypeConfiguration<Facturaspago>
    {
        public void Configure(EntityTypeBuilder<Facturaspago> entity)
        {
            entity.HasKey(e => e.FacturasCabeceraFacturaPago).HasName("PRIMARY");
            entity.ToTable("facturaspagos", x => x.ExcludeFromMigrations());
            entity.HasIndex(e => e.FacturasCabeceraFacturaPago, "FacturasCabeceraFacturaPago").IsUnique();
            entity.Property(e => e.FacturasCabeceraFacturaPago).HasMaxLength(36).HasDefaultValueSql("''");
            entity.Property(e => e.AnticipoFacturaPago).HasPrecision(16, 4);
            entity.Property(e => e.ChequeFacturaPago).HasPrecision(16, 4);
            entity.Property(e => e.CreditoFacturaPago).HasPrecision(16, 4);
            entity.Property(e => e.CuponFacturaPago).HasPrecision(16, 4);
            entity.Property(e => e.EfectivoFacturapago).HasPrecision(16, 4);
            entity.Property(e => e.OtrosFacturaPago).HasPrecision(16, 4);
            entity.Property(e => e.TarjetaFacturaPago).HasPrecision(16, 4);
            entity.HasOne(d => d.Billing).WithOne(p => p.Facturaspago).HasForeignKey<Facturaspago>(d => d.FacturasCabeceraFacturaPago).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_cabeceraFactura_Pagos");
        }
    }
}
