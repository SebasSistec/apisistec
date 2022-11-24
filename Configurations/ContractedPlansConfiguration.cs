using apisistec.Entities;
using apisistec.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class ContractedPlansConfiguration : IEntityTypeConfiguration<ContractedPlans>
    {
        public void Configure(EntityTypeBuilder<ContractedPlans> builder)
        {
            builder.ToTable("plnp_contracted_plans");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");
            builder.Property(x => x.TotalValue)
                .HasColumnName("total")
                .IsRequired()
                .HasPrecision(16, 4);
            builder.Property(x => x.SubtotalZero)
                .HasColumnName("subtotal_zero")
                .IsRequired()
                .HasPrecision(16, 4);
            builder.Property(x => x.SubtotalIva)
                .HasColumnName("subtotal_iva")
                .IsRequired()
                .HasPrecision(16, 4);
            builder.Property(x => x.IvaValue)
                .HasColumnName("iva_value")
                .IsRequired()
                .HasPrecision(16, 4);
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("'1990-01-01 00:00:00'");
            builder.Property(x => x.ProvinceInec)
                .HasColumnName("province_inec")
                .HasColumnType("VARCHAR(5)");
            builder.Property(x => x.CantonInec)
                .HasColumnName("canton_inec")
                .HasColumnType("VARCHAR(5)");
            builder.Property(x => x.Lat)
                .HasColumnName("lat")
                .HasColumnType("VARCHAR(30)");
            builder.Property(x => x.Lng)
                .HasColumnName("lng")
                .HasColumnType("VARCHAR(30)");
            builder.Property(x => x.EDocsCount)
                .HasColumnName("e-docs-count")
                .HasColumnType("bigint(10)");
            builder.Property(x => x.Type)
               .HasColumnName("type")
               .HasColumnType("int(1)")
               .HasEnumComment();
            builder.Property(x => x.PaymentState)
               .HasColumnName("payment_state")
               .HasColumnType("int(1)")
               .HasEnumComment();
            builder.Property(x => x.EndDate)
                .HasColumnName("end_date")
                .IsRequired()
                .HasColumnType("DATETIME");
            builder.Property(x => x.RucQty)
               .HasColumnName("ruc_qty")
               .IsRequired()
               .HasColumnType("int(4)");

            //FK Client 
            builder.Property(x => x.ClientId)
                .HasColumnName("FK_client_id")
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Client)
                .WithMany(x => x.ContractedPlans)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK Billing
            builder.Property(x => x.BillId)
                .HasColumnName("FK_billing_id")
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Billing)
                .WithMany(x => x.ContractedPlans)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK Plan
            builder.Property(x => x.PlanId)
                .HasColumnName("FK_plan_id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.ContractedPlans)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK User
            builder.Property(x => x.UserId)
                .HasColumnName("FK_user_id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.User)
                .WithMany(x => x.ContractedPlans)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
