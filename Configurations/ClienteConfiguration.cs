using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.CodigoCliente)
                    .HasName("PRIMARY");

            entity.ToTable("clientes", x => x.ExcludeFromMigrations());

            entity.HasComment("Cliente;NombreCliente,ApellidoCliente;NombreComercialCliente");

            entity.HasIndex(e => e.ApellidoCliente, "ApellidoCliente");

            entity.HasIndex(e => e.TiposClienteCarteraCliente, "FK_TiposClienteCarteraCliente");

            entity.HasIndex(e => e.NumeroIdentificacionCliente, "Identificaion")
                .IsUnique();

            entity.HasIndex(e => e.NombreCliente, "NombreCliente");

            entity.HasIndex(e => e.NombreComercialCliente, "NombreComercialCliente");

            entity.HasIndex(e => e.TiposClienteCliente, "TiposClienteCliente");

            entity.HasIndex(e => e.TiposIdentificacionCliente, "TiposIdentificacionCliente");

            entity.HasIndex(e => e.CodigoCliente, "codigocliente")
                .IsUnique();

            entity.HasIndex(e => e.TransportesCliente, "transporte");

            entity.Property(e => e.CodigoCliente).HasMaxLength(36);

            entity.Property(e => e.AgrocalidadCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.ApellidoCliente).HasMaxLength(60);

            entity.Property(e => e.ApellidoConyugeCliente)
                .HasMaxLength(60)
                .HasDefaultValueSql("''");

            entity.Property(e => e.AplicaPromocionCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("0");

            entity.Property(e => e.BodegasCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'130206666653994'");

            entity.Property(e => e.CalificacionPagoCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength();

            entity.Property(e => e.CalificacionTipoCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'E'");

            entity.Property(e => e.CalificacionUtilidadCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength();

            entity.Property(e => e.CedulaConyugeCliente)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");

            entity.Property(e => e.CedulaRepresentanteLegalCliente)
                .HasMaxLength(10)
                .HasDefaultValueSql("''");

            entity.Property(e => e.CiudadesCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.CodigoSecuencialCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            entity.Property(e => e.ContactoCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.ContribuyenteEspecialCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.CuentasContabilidadCliente).HasMaxLength(18);

            entity.Property(e => e.DiasDemoraEntregaCliente)
                .HasColumnType("int(2)")
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.DinardapCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.DireccionDosCliente)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");

            entity.Property(e => e.DireccionUnoCliente).HasMaxLength(100);

            entity.Property(e => e.EmailDespahosCliente).HasColumnType("text");

            entity.Property(e => e.EmiteRetencionCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("Permite determinar si el cliente emite retenciones");

            entity.Property(e => e.EmpleadoEmpresaCliente)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.EstadoCivilCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'S'")
                .HasComment("S SOLTERO C CASADO V VIUDO D DIVORCIADO U UNION LIBRE");

            entity.Property(e => e.EstatalCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.ExigirDocumentosCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.FechaHastaCupoCalificacionCliente).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaNacimientoCliente).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaNacimientoConyugeCliente).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaRegistroCupoCalificacionCliente).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.ListasPrecioCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.ListasPrecioMaximaCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            entity.Property(e => e.MailCliente).HasColumnType("text");

            entity.Property(e => e.MontoMaximoConsignacionCliente).HasPrecision(16, 4);

            entity.Property(e => e.MontoMinimoCreditoCliente).HasColumnType("double(16,4)");

            entity.Property(e => e.NombreCliente)
                .HasMaxLength(60)
                .HasDefaultValueSql("''");

            entity.Property(e => e.NombreComercialCliente)
                .HasMaxLength(200)
                .HasDefaultValueSql("''");

            entity.Property(e => e.NombreConyugeCliente)
                .HasMaxLength(60)
                .HasDefaultValueSql("''");

            entity.Property(e => e.NumeroIdentificacionCliente).HasMaxLength(20);

            entity.Property(e => e.ObservacionCliente).HasColumnType("text");

            entity.Property(e => e.OmitirCupoCalificacionCliente)
                .HasMaxLength(5)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.OmitirDescuentoCliente)
                .HasMaxLength(5)
                .HasDefaultValueSql("''");

            entity.Property(e => e.PagaChequeCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.PagaChequePosfechadoCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.PrioridadNombreComercialCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.PuedeTenerConsignacionCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.RelacionCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.RelacionadoEmpresaCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("indica si el cliente esta relacionado con la empresa.");

            entity.Property(e => e.RutasEntregasCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            entity.Property(e => e.SectorDireccionCliente)
                .HasMaxLength(150)
                .HasDefaultValueSql("''");

            entity.Property(e => e.SexoCliente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'M'")
                .HasComment("M MASCULINO F FEMENINO");

            entity.Property(e => e.SolicitudesCreditoCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            entity.Property(e => e.TamanioNegociosCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.TelefonoCincoCliente)
                .HasMaxLength(12)
                .HasDefaultValueSql("''");

            entity.Property(e => e.TelefonoCuatroCliente)
                .HasMaxLength(12)
                .HasDefaultValueSql("''");

            entity.Property(e => e.TelefonoDosCliente)
                .HasMaxLength(15)
                .HasDefaultValueSql("''");

            entity.Property(e => e.TelefonoSeisCliente)
                .HasMaxLength(12)
                .HasDefaultValueSql("''");

            entity.Property(e => e.TelefonoTresCliente)
                .HasMaxLength(12)
                .HasDefaultValueSql("''");

            entity.Property(e => e.TelefonoUnoCliente).HasMaxLength(12);

            entity.Property(e => e.TiposClienteCarteraCliente)
                .HasMaxLength(30)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.TiposClienteCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.TiposIdentificacionCliente).HasMaxLength(20);

            entity.Property(e => e.TiposNegocioCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.TiposNegocioSecundarioCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.TiposNegociosCalificacionCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.Tiposclientesegurocliente)
                .HasMaxLength(30)
                .HasColumnName("tiposclientesegurocliente")
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.TitulosCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.TransportesCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.UsuariosCliente).HasMaxLength(45);

            entity.Property(e => e.UsuariosModificaCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("''");

            entity.Property(e => e.WebCliente)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");

            entity.Property(e => e.ZonasCliente)
                .HasMaxLength(20)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.NombreCompleto)
               .HasMaxLength(200)
               .HasDefaultValueSql("'");

            entity.Property(e => e.FechaRegistro)
               .HasMaxLength(20)
               .HasDefaultValueSql("'1900-01-01'");
        }
    }
}
