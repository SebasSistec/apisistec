using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class ProjectsConfiguration : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.ToTable("spt_projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
