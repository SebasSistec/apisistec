using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class RestorePasswordConfiguration : IEntityTypeConfiguration<RestorePassword>
    {
        public void Configure(EntityTypeBuilder<RestorePassword> builder)
        {
            builder.ToTable("plnp_restore_passwords");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("VARCHAR(36)");
            builder.Property(c => c.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasColumnType("VARCHAR(255)");
        }
    }
}
