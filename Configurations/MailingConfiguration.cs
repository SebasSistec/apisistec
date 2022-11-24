using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class MailingConfiguration : IEntityTypeConfiguration<Mailing>
    {
        public void Configure(EntityTypeBuilder<Mailing> builder)
        {
            builder.ToTable("plnp_mailing");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("varchar(36)");
            builder.Property(x => x.Host)
                .HasColumnName("host")
                .IsRequired()
                .HasColumnType("varchar(30)");
            builder.Property(x => x.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasColumnType("varchar(80)");
            builder.Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasColumnType("varchar(30)");
            builder.Property(x => x.Port)
                .HasColumnName("port")
                .IsRequired()
                .HasColumnType("int(3)");
            builder.Property(x => x.Ssl)
                .HasColumnName("ssl")
                .IsRequired()
                .HasColumnType("int(1)");
        }
    }
}
