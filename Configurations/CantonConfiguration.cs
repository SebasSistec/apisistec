using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class CantonConfiguration : IEntityTypeConfiguration<Cantones>
    {
        public void Configure(EntityTypeBuilder<Cantones> builder)
        {
            builder.ToTable("localizacionesCantones");
            builder.HasKey(e => e.CodigoLocalizacionCanton)
                    .HasName("PRIMARY");

            builder.HasComment("Ciudad;NombreLocalizacionCiudad");

            builder.HasIndex(e => e.AbreviadoLocalizacionCanton, "Index_Abreviado")
                .IsUnique();

            builder.HasIndex(e => e.NombreLocalizacionCanton, "Index_NombreCiudad");

            builder.HasIndex(e => e.ProvinciasLocalizacionCanton, "ProvinciasLocalizacionCanton");

            builder.Property(e => e.CodigoLocalizacionCanton)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("Codigo Ciudad;text;true;false;Datos;80;left");

            builder.Property(e => e.AbreviadoLocalizacionCanton)
                .HasMaxLength(6)
                .HasDefaultValueSql("''")
                .HasComment("Nombre Abreviado;text;true;true;Datos;180;left");

            builder.Property(e => e.CodigoInecLocalizacionCanton)
                .HasMaxLength(3)
                .HasDefaultValueSql("''");

            builder.Property(e => e.NombreLocalizacionCanton)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasComment("Nombre Ciudad;text;true;true;Datos;180;left");

            builder.Property(e => e.ProvinciasLocalizacionCanton)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("Provincia Ciudad;combo;true;true;Datos;180;left; select CodigoLocalizacionProvincia, NombreLocalizacionProvincia from localizacionesprovincias");

            builder.Property(e => e.UsuariosLocalizacionCanton)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            builder.HasOne(d => d.Provincia)
                .WithMany(p => p.Cantones)
                .HasForeignKey(d => d.ProvinciasLocalizacionCanton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocalizacionCanton_Provincia");
        }
    }
}
