using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class ModulesConfiguration : IEntityTypeConfiguration<Modules>
    {
        public void Configure(EntityTypeBuilder<Modules> builder)
        {
            builder.ToTable("spt_modules");

            builder.HasKey(p => p.id);

            builder.Property(p => p.id)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.Property(p => p.name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.description)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(p => p.createdAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
