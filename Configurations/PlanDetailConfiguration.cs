using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class PlanDetailConfiguration : IEntityTypeConfiguration<PlanDetail>
    {
        public void Configure(EntityTypeBuilder<PlanDetail> builder)
        {
            builder.ToTable("plnp_plan_details");
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
        }
    }
}
