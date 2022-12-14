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

            builder.HasKey(p => p.id);

            builder.Property(p => p.id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.Property(p => p.name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.description)
                .HasColumnName("description")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(p => p.createdAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
