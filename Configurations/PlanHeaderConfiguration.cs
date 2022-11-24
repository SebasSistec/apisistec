using apisistec.Entities;
using apisistec.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class PlanHeaderConfiguration : IEntityTypeConfiguration<PlanHeader>
    {
        public void Configure(EntityTypeBuilder<PlanHeader> builder)
        {
            builder.ToTable("plnp_plans");
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id)
                .HasColumnName("id")
                .HasColumnType("VARCHAR(36)");
            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasColumnType("VARCHAR(100)");
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasColumnType("VARCHAR(255)");
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("'1990-01-01 00:00:00'");
            builder.Property(x => x.StartAt)
                .HasColumnName("start_at")
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("'1990-01-01 00:00:00'");
            builder.Property(x => x.EndAt)
                .HasColumnName("end_at")
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("'1990-01-01 00:00:00'");
            builder.Property(x => x.State)
                .HasColumnName("state")
                .IsRequired()
                .HasColumnType("int(1)")
                .HasEnumComment();
            builder.Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired()
                .HasColumnType("DECIMAL(16,4)");
            builder.Property(x => x.PastPrice)
                .HasColumnName("past_price")
                .IsRequired()
                .HasColumnType("DECIMAL(16,4)");
            builder.Property(x => x.DiscountPercent)
                .HasColumnName("discount_percent")
                .IsRequired()
                .HasColumnType("DECIMAL(16,4)");
            builder.Property(x => x.PastDiscountPercent)
                .HasColumnName("past_discount_percent")
                .IsRequired()
                .HasColumnType("DECIMAL(16,4)");
            builder.Property(x => x.TransacctionQty)
                .HasColumnName("transacction_qty")
                .IsRequired()
                .HasColumnType("int(4)");
            builder.Property(x => x.RucQty)
                .HasColumnName("ruc_qty")
                .IsRequired()
                .HasColumnType("int(4)");
            builder.Property(x => x.MonthsAvailables)
                .HasColumnName("months_availables")
                .IsRequired()
                .HasColumnType("int(4)");
            builder.Property(x => x.Type)
                .HasColumnName("type")
                .HasColumnType("int(1)")
                .HasEnumComment();
            builder.Property(x => x.ProductId)
                .HasColumnName("FK_product")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");
            builder.HasOne(x => x.Product)
                .WithMany(x => x.PlanPackages)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
