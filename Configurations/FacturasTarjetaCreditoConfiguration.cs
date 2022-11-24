using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class FacturasTarjetaCreditoConfiguration : IEntityTypeConfiguration<Facturastarjetacredito>
    {
        public void Configure(EntityTypeBuilder<Facturastarjetacredito> entity)
        {
            entity.HasKey(e => e.CodigoFacturaTarjetaCredito).HasName("PRIMARY");
            entity.ToTable("facturastarjetacredito", x => x.ExcludeFromMigrations());
            entity.HasIndex(e => e.CodigoFacturaTarjetaCredito, "index_CodigoFacturaTarjetaCredito").IsUnique();
            entity.HasIndex(e => e.CodigoMovimiento, "index_CodigoMovimiento");
            entity.HasIndex(e => e.FacturasCabeceraFacturaTarjetaCredito, "index_FacturasCabeceraFacturaTarjetaCredito");
            entity.Property(e => e.CodigoFacturaTarjetaCredito).HasMaxLength(36);
            entity.Property(e => e.AnuladoFacturaTarjetaCredito).HasMaxLength(1).HasDefaultValueSql("'0'");
            entity.Property(e => e.CodigoMovimiento).HasMaxLength(20).HasDefaultValueSql("''");
            entity.Property(e => e.DepositosTarjetaCreditoFacturaTarjetaCredito).HasMaxLength(20);
            entity.Property(e => e.FacturasCabeceraFacturaTarjetaCredito).HasMaxLength(36).HasDefaultValueSql("''");
            entity.Property(e => e.LoteFacturaTarjetaCredito).HasMaxLength(20);
            entity.Property(e => e.NumeroTarjetaFacturaTarjetaCredito).HasMaxLength(50).HasDefaultValueSql("''").IsFixedLength();
            entity.Property(e => e.PagadaFacturaTarjetaCredito).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("0 = No Depositado\r\n1 = Depositado");
            entity.Property(e => e.ReferenciaFacturaTarjetaCredito).HasMaxLength(20);
            entity.Property(e => e.TajetasCreditoFacturaTarjetaCredito).HasMaxLength(20).HasDefaultValueSql("''");
            entity.Property(e => e.TipoCuentaBancariaFacturaTarjetaCredito).HasMaxLength(1).HasDefaultValueSql("'T'");
            entity.Property(e => e.TiposFinanciamientosFacturaTarjetaCredito).HasMaxLength(20);
            entity.Property(e => e.ValorTarjetaFacturaTarjetaCredito).HasColumnType("double(16,4)");
        }
    }
}
