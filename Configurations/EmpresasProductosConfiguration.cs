using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class EmpresasProductosConfiguration : IEntityTypeConfiguration<EmpresasProductos>
    {
        public void Configure(EntityTypeBuilder<EmpresasProductos> builder)
        {
            builder.HasKey(x => new {x.EmpresasEmpresaProducto, x.ProductosEmpresaProducto});

            builder.Property(x => x.EmpresasEmpresaProducto)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(x => x.ProductosEmpresaProducto)
                .IsRequired()
                .HasColumnType("varchar");
            
            builder.Property(x => x.PrecioVentaProducto)
                .IsRequired()
                .HasColumnType("decimal");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Pricing)
                .HasForeignKey(x => x.ProductosEmpresaProducto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
