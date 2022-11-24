using apisistec.Entities;
using apisistec.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("plnp_users");
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.Email, "Email").IsUnique();
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("VARCHAR(36)");
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasColumnType("VARCHAR(100)");
            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasColumnType("VARCHAR(100)");
            builder.Property(x => x.PasswordTemp)
                .HasColumnName("password_temp")
                .IsRequired()
                .HasColumnType("VARCHAR(100)");
            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasColumnType("VARCHAR(100)");
            builder.Property(x => x.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired()
                .HasColumnType("BLOB");
            builder.Property(x => x.PasswordSalt)
                .HasColumnName("password_salt")
                .IsRequired()
                .HasColumnType("BLOB");
            builder.Property(u => u.Phone)
                .HasColumnName("phone")
                .IsRequired()
                .HasColumnType("VARCHAR(15)");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("created_at")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("'1990-01-01 00:00:00'");
            builder.Property(x => x.State)
                .HasColumnName("state")
                .IsRequired()
                .HasColumnType("int(1)")
                .HasEnumComment();
            builder.Property(x => x.EmailVerified)
                .HasColumnName("email_verified")
                .IsRequired()
                .HasColumnType("int(1)")
                .HasEnumComment();
        }
    }
}
