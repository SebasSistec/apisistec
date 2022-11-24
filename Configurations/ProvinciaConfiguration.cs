using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincias>
    {
        public void Configure(EntityTypeBuilder<Provincias> builder)
        {
            builder.ToTable("localizacionesprovincias");

            builder.HasKey(e => e.CodigoLocalizacionProvincia)
                    .HasName("PRIMARY");

            builder.HasComment("Provincia;NombreLocalizacionProvincia");

            builder.HasIndex(e => e.AbreviadoLocalizacionProvincia, "Index_Abreviado")
                .IsUnique();

            builder.HasIndex(e => e.NombreLocalizacionProvincia, "Index_NombreProvincia")
                .IsUnique();

            builder.HasIndex(e => e.PaisesLocalizacionProvincia, "Paises");

            builder.Property(e => e.CodigoLocalizacionProvincia)
                .HasMaxLength(20)
                .HasComment("Codigo Provincia;text;true;false;Datos;80;left");

            builder.Property(e => e.AbreviadoLocalizacionProvincia)
                .HasMaxLength(20)
                .HasComment("Nombre Abreviado;text;true;true;Datos;120;left");

            builder.Property(e => e.CodigoInecLocalizacionProvincia)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .HasComment("Codigo Registro Provincia;text;true;true;Datos;80;left");

            builder.Property(e => e.CodigoMatriculacionLocalizacionProvincia)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            builder.Property(e => e.NombreLocalizacionProvincia)
                .HasMaxLength(60)
                .HasComment("Nombre Provincia;text;true;true;Datos;120;left");

            builder.Property(e => e.PaisesLocalizacionProvincia)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            builder.Property(e => e.UsuariosLocalizacionProvincia).HasMaxLength(20);
        }
    }
}
