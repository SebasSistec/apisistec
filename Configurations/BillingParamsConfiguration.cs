using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class BillingParamsConfiguration : IEntityTypeConfiguration<BillingParams>
    {
        public void Configure(EntityTypeBuilder<BillingParams> builder)
        {
            builder.ToTable("plnp_billing_params");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.Property(x => x.IsValidPayment)
                .HasColumnName("valid_payment")
                .IsRequired()
                .HasColumnType("int(1)");

            //FK Product
            builder.Property(x => x.ProductoId)
                .HasColumnName("FK_producto_id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Producto)
                .WithMany(x => x.BillingParams)
                .HasForeignKey(x => x.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK Warehouse
            builder.Property(x => x.BodegaId)
                .HasColumnName("FK_bodega_id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Bodega)
                .WithMany(x => x.BillingParams)
                .HasForeignKey(x => x.BodegaId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK Billing Points
            builder.Property(x => x.PuntoFacturaId)
                .HasColumnName("FK_punto_factura_id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Puntosfactura)
                .WithMany(x => x.BillingParams)
                .HasForeignKey(x => x.PuntoFacturaId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK Employees
            builder.Property(x => x.EmpleadoId)
                .HasColumnName("FK_empleado_id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Empleado)
                .WithMany(x => x.BillingParams)
                .HasForeignKey(x => x.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
