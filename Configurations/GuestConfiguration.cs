using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guests>
    {
        public void Configure(EntityTypeBuilder<Guests> builder)
        {
            builder.ToTable("plnp_guests");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.Property(x => x.firstName)
               .IsRequired()
               .HasColumnName("first_name")
               .HasColumnType("varchar")
               .HasMaxLength(150);

            builder.Property(x => x.lastName)
              .IsRequired()
              .HasColumnName("last_name")
              .HasColumnType("varchar")
              .HasMaxLength(150);

            builder.Property(x => x.email)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(150);

            builder.Property(x => x.phone)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(15);

            builder.Property(x => x.createdAt)
              .IsRequired()
              .HasColumnName("created_at")
              .HasColumnType("datetime")
              .HasDefaultValueSql("'1990-01-01 00:00:00'");
        }
    }
}
