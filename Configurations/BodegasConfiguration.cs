using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class BodegasConfiguration : IEntityTypeConfiguration<Bodega>
    {
        public void Configure(EntityTypeBuilder<Bodega> entity)
        {
            entity.HasKey(e => e.CodigoBodega)
                    .HasName("PRIMARY");

            entity.ToTable("bodegas", x => x.ExcludeFromMigrations());

            entity.HasComment("Bodega;like NombreBodegas");

            entity.HasIndex(e => e.CodigoBodega, "CodigoBodega");

            entity.HasIndex(e => new { e.NombreBodega, e.EmpresasBodega }, "Index_Nombre")
                .IsUnique();

            entity.HasIndex(e => e.UsuariosBodega, "Index_Usuario");

            entity.HasIndex(e => e.EmpresasBodega, "empresabogeda");

            entity.Property(e => e.CodigoBodega)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("Codigo Bodega;text;true;false;Datos;180;left");

            entity.Property(e => e.Activarparaxadis)
                .HasColumnType("int(1)")
                .HasColumnName("activarparaxadis");

            entity.Property(e => e.ActivosBodega)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("Bodega de Activos;chk;true;true;Datos;180;left");

            entity.Property(e => e.CodigoEcommerceBodega)
                .HasMaxLength(20)
                .HasColumnName("codigoEcommerceBodega")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.ConsignacionBodega)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("Bodega consignar;chk;true;true;Datos;180;left");

            entity.Property(e => e.DeshabilitadaBodega)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'")
                .HasComment("Bodega Deshabilitada;chk;true;true;Datos;180;left");

            entity.Property(e => e.EmpresasBodega)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasComment("Empresa a la que pertenece;cmb;true;true;Datos;180;left;select codigoempresa,nombreempresa from empresas");

            entity.Property(e => e.FacturaBodega)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("Bodega para facturar;chk;true;true;Datos;180;left");

            entity.Property(e => e.GenerarPendienteDespachoBodega)
                .HasColumnType("int(1)")
                .HasComment("Generar Pendientes Despacho;chk;true;true;Datos;180;left");

            entity.Property(e => e.InventarioBodega)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasComment("Considera Inventario;chk;true;true;Datos;180;left");

            entity.Property(e => e.NombreBodega)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasComment("Nombre Bodega;text;true;true;Datos;180;left");

            entity.Property(e => e.NumeroOrdenBodega)
                .HasColumnType("int(10)")
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.ReposicionBodega)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'")
                .HasComment("Considera para reposicion;chk;true;true;Datos;180;left");

            entity.Property(e => e.SecuenciaDevolucionBodega)
                .HasColumnType("int(10)")
                .HasDefaultValueSql("'1'")
                .HasComment("Secuencia Devolucion Mercaderia;text;true;true;Datos;180;left");

            entity.Property(e => e.SincronizarBodega)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.SincronizarEcommerceBodega)
                .HasColumnType("int(1)")
                .HasComment("Sincronizar Ecommerce;chk;true;true;Datos;180;left");

            entity.Property(e => e.SucursalesBodega)
                .HasMaxLength(20)
                .HasDefaultValueSql("'wise'")
                .HasComment("Sucursal a la que pertenece;cmb;true;true;Datos;180;left;select codigosucursal,nombresucursal from sucursales");

            entity.Property(e => e.UsuariosBodega).HasMaxLength(20);
        }
    }
}
