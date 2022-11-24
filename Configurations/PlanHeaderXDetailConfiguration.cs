using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class PlanHeaderXDetailConfiguration : IEntityTypeConfiguration<PlanHeaderXDetail>
    {
        public void Configure(EntityTypeBuilder<PlanHeaderXDetail> builder)
        {
            builder.ToTable("plnp_plan_per_details");
            builder.HasKey(x => new { x.PlanHeaderId, x.PlanDetailId }).HasName("foreign_keys");
            builder.Property(x => x.Order)
                .HasColumnName("order")
                .IsRequired()
                .HasColumnType("int(2)");

            //FK Plan Header
            builder.Property(x => x.PlanHeaderId)
                .HasColumnName("FK_plan_header")
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Header)
                .WithMany(x => x.PlanHeaderXDetail)
                .HasForeignKey(x => x.PlanHeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            //FK Plan Detail
            builder.Property(x => x.PlanDetailId)
                .HasColumnName("FK_plan_detail")
                .HasColumnType("VARCHAR(36)");

            builder.HasOne(x => x.Detail)
                .WithMany(x => x.PlanHeaderXDetail)
                .HasForeignKey(x => x.PlanDetailId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
