using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace apisistec.Configurations
{
    public class ProductosConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PRIMARY");

            entity.ToTable("productos", x => x.ExcludeFromMigrations());

            entity.HasComment("Producto;DescripcionProducto,Abrevia");

            entity.HasIndex(e => e.ArancelesProducto, "Aranceles");

            entity.HasIndex(e => e.CodigoBarraProducto, "CodigoBarraProducto").IsUnique();

            entity.HasIndex(e => e.CodigoCatalogoProducto, "CodigoCatalogoProducto");

            entity.HasIndex(e => e.CodigoCompraProducto, "CodigoCompraProducto");

            entity.HasIndex(e => e.CodigoProducto, "CodigoProducto").IsUnique();

            entity.HasIndex(e => e.CodigoTipoPorcentajeIce, "CodigoTipoPorcentajeICE");

            entity.HasIndex(e => e.ColoresProducto, "Colores");

            entity.HasIndex(e => e.CondicionesAlmacenamientoArcsaProducto, "CondicionesAlmacenamientoArcsaProducto");

            entity.HasIndex(e => e.CuentasContabilidadDevolucionProducto, "CuentaDevoluciones");

            entity.HasIndex(e => e.CuentasContabilidadActivoProducto, "CuentasAcitvo");

            entity.HasIndex(e => e.CuentasContabilidadCompraProducto, "CuentasContabilidadCompraProducto");

            entity.HasIndex(e => e.CuentasContabilidadCostoProducto, "CuentasCosto");

            entity.HasIndex(e => e.CuentasContabilidadVentaProducto, "CuentasVentas");

            entity.HasIndex(e => e.CuentasContabilidadCuponProducto, "FK_CuentasContabilidadCuponProducto");

            entity.HasIndex(e => e.GruposProducto, "Grupos");

            entity.HasIndex(e => e.ServicioProducto, "Ind_ServicioProducto");

            entity.HasIndex(e => e.CodigoVentaProducto, "Index_CodigoVenta").IsUnique();

            entity.HasIndex(e => e.LineasProducto, "Lineas");

            entity.HasIndex(e => e.ListasPrecioProducto, "ListasPrecioProducto");

            entity.HasIndex(e => e.MarcasProducto, "Marcas");

            entity.HasIndex(e => e.CategoriasProducto, "categorias");

            entity.HasIndex(e => e.CategoriasEspecialesProducto, "productos_ibfk_1");

            entity.HasIndex(e => e.ProductosTipoProducto, "tiposproducto");

            entity.HasIndex(e => e.UnidadesProducto, "unidades");

            entity.Property(e => e.CodigoProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo;text;true;false;Administracion;180;left");

            entity.Property(e => e.AccesorioProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es un Accesorio;chk;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.ActivoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es parte del Activo;chk;true;true;Administracion;180;left");

            entity.Property(e => e.AltoProducto).HasPrecision(19, 12).HasComment("Alto;text;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.AnchoProducto).HasPrecision(19, 12).HasComment("Ancho;text;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.Anio).HasMaxLength(36).HasColumnName("_Anio");

            entity.Property(e => e.ArancelesProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.CalificacionProducto).HasMaxLength(1).HasDefaultValueSql("'D'");

            entity.Property(e => e.CantidadLitrosProducto).HasPrecision(16, 4);

            entity.Property(e => e.CantidadSumaBonificacionProducto).HasPrecision(16, 4);

            entity.Property(e => e.Capacidad).HasMaxLength(36).HasColumnName("_Capacidad");

            entity.Property(e => e.CategoriasEcommerceProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.CategoriasEspecialesProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.CategoriasProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.CategoriasServicioTecnicoProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.Cilindraje).HasMaxLength(36).HasColumnName("_Cilindraje");

            entity.Property(e => e.CodigoBarraProducto).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Codigo de Barras;text;true;true;Administracion;180;left");

            entity.Property(e => e.CodigoCatalogoProducto).HasMaxLength(40).HasDefaultValueSql("''").HasComment("Codigo en Catalogo;text;true;true;Administracion;180;left");

            entity.Property(e => e.CodigoCompraProducto).HasMaxLength(40).HasDefaultValueSql("''").HasComment("Codigo en Compra;text;true;true;Administracion;180;left");

            entity.Property(e => e.CodigoTipoPorcentajeIce).HasMaxLength(30).HasColumnName("CodigoTipoPorcentajeICE").HasDefaultValueSql("'0'");

            entity.Property(e => e.CodigoVentaProducto).HasMaxLength(40).HasDefaultValueSql("''").HasComment("Codigo de Item;text;true;true;Administracion;180;left");

            entity.Property(e => e.ColoresProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.ComboProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Verifica si el producto es un combo");

            entity.Property(e => e.Combustible).HasMaxLength(36).HasColumnName("_Combustible");

            entity.Property(e => e.CompresionServicio).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.CondicionesAlmacenamientoArcsaProducto).HasMaxLength(20);

            entity.Property(e => e.ControlarBufferProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.ControlarPesoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Se debe controlar su Peso;chk;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.ControlesProducto).HasColumnType("text").HasComment("Almacena el tipo de control en el caso de ser agroquimico");

            entity.Property(e => e.CuentasContabilidadActivoProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadCompraProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadCostoProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadCuponProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadDescuentoProducto).HasMaxLength(20).HasDefaultValueSql("'41010001001'");

            entity.Property(e => e.CuentasContabilidadDevolucionProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadVentaProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CultivoProucto).HasColumnType("text").HasComment("Permite saber si el producto se aplica a algun tipo de cultivo en caso de ser agroquimio");

            entity.Property(e => e.DatoAdicionalProducto).HasColumnType("text");

            entity.Property(e => e.DatosGeneralesProducto).HasColumnType("text");

            entity.Property(e => e.DeclaraArcsaProducto).HasColumnType("int(1)");

            entity.Property(e => e.DescripcionAdicionalProducto).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Descripcion Adicional;text;true;true;Administracion;180;left");

            entity.Property(e => e.DescripcionCortaProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Descripcion Corta;text;true;true;Administracion;180;left");

            entity.Property(e => e.DescripcionProducto).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Nombre-Descripcion;text;true;true;Administracion;180;left");

            entity.Property(e => e.DescuentoComboProducto).HasColumnType("double(16,4)").HasComment("Establece el porcentaje de descuento en los productos del combo");

            entity.Property(e => e.DescuentoProducto).HasPrecision(16, 4);

            entity.Property(e => e.DeshabilitadoProducto).HasColumnType("int(1)");

            entity.Property(e => e.DesventajasProducto).HasColumnType("text");

            entity.Property(e => e.DosisProducto).HasColumnType("text").HasComment("Almacena la dosis del producto en el caso de ser agroquimico");

            entity.Property(e => e.EcommerceIdProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.EsServicioRecargasProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.FacturaComboProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Verifica si se factura el combo o cada uno de los productos");

            entity.Property(e => e.FacturarDecimalesProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.FavoritoProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.FechaCreacionProducto).HasDefaultValueSql("'2000-01-01'");

            entity.Property(e => e.FechaVigenciaRegistroSanitarioProducto).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FrecuenciasProducto).HasColumnType("text").HasComment("Almacena la frecuencia de administracion del produto en caso de ser agroquimico");

            entity.Property(e => e.GeneraOrdenServicioTecnicoProducto).HasColumnType("int(1)");

            entity.Property(e => e.GradoAlcoholicoProducto).HasPrecision(16, 4);

            entity.Property(e => e.GruposCaracteristicasProducto).HasMaxLength(20);

            entity.Property(e => e.GruposEcommerceProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.GruposProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.IngresaMotorChasisProducto).HasColumnType("int(1)");

            entity.Property(e => e.LineasEcommerceProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.LineasProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.ListasPrecioProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.LoteProducto).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.MarcasProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.MateriaPrimaProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Item de Materia Prima;chk;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.MetrajeProducto).HasPrecision(16, 4);

            entity.Property(e => e.MigarEcommerceProducto).HasColumnType("int(1)");

            entity.Property(e => e.NombreComercialProducto).HasMaxLength(300).HasDefaultValueSql("''");

            entity.Property(e => e.NumeroEjes).HasMaxLength(36).HasColumnName("_NumeroEjes");

            entity.Property(e => e.NumeroRegistroSanitarioProducto).HasMaxLength(50).HasDefaultValueSql("''");

            entity.Property(e => e.NumeroRuedas).HasMaxLength(36).HasColumnName("_NumeroRuedas");

            entity.Property(e => e.ObservacionProducto).HasColumnType("text").HasComment("Observaciones;text;true;true;Observaciones;180;left");

            entity.Property(e => e.PagaIceProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.PagaIvaProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Item con I.V.A.;chk;true;true;Administracion;180;left");

            entity.Property(e => e.PaisOrigen).HasMaxLength(36).HasColumnName("_PaisOrigen");

            entity.Property(e => e.PerchaProducto).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Percha en Bodega;text;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.PesoProducto).HasPrecision(16, 4).HasComment("Peso;text;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.PlanAnchoBanda).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.PorcentajeBonificacionProducto).HasPrecision(16, 4);

            entity.Property(e => e.PorcentajeDescuentoProducto).HasPrecision(16, 4);

            entity.Property(e => e.PrecioFofproducto).HasPrecision(16, 4).HasColumnName("PrecioFOFProducto");

            entity.Property(e => e.PrecioProveedorLocalProducto).HasPrecision(16, 4);

            entity.Property(e => e.ProductosTipoProducto).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.ProfundidadProducto).HasPrecision(19, 12).HasComment("Ancho;text;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.PromocionProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.ProveedoresProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.RecargoProducto).HasPrecision(16, 4);

            entity.Property(e => e.RecetaProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Item posee Receta?;chk;true;true;Administracion;180;left");

            entity.Property(e => e.RepuestoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es un Repuesto;chk;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.SeleccionarPorcionesProducto).HasColumnType("int(1)");

            entity.Property(e => e.SerieLoteProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Requiere Ingresar Numeros de Serie;chk;true;true;Administracion;180;left");

            entity.Property(e => e.ServicioProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Establecer como Servicio;chk;true;true;Administracion;180;left");

            entity.Property(e => e.SincronizarAppProducto).HasMaxLength(1).HasDefaultValueSql("'1'");

            entity.Property(e => e.SincronizarWebProducto).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.SumarNumeroFilasBonificacionProducto).HasPrecision(16, 4);

            entity.Property(e => e.SustitutoProducto).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("Es un Sustituto de otro Item;text;true;true;Otras Consideraciones;180;left");

            entity.Property(e => e.TiempomedioServicioTecnicoProducto).HasColumnType("int(6)");

            entity.Property(e => e.TipoExtrasProducto).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.Tonelaje).HasMaxLength(36).HasColumnName("_Tonelaje");

            entity.Property(e => e.UnidadesCajaProducto).HasPrecision(16, 4);

            entity.Property(e => e.UnidadesProducto).HasMaxLength(20).HasDefaultValueSql("'1'");

            entity.Property(e => e.UsuariosProducto).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");

            entity.Property(e => e.ValorIcexItemProducto).HasPrecision(16, 4).HasColumnName("ValorICExItemProducto");

            entity.Property(e => e.ValorXlitroAlcoholProducto).HasPrecision(16, 4);

            entity.Property(e => e.VariacionCostoProduccionProducto).HasPrecision(16, 2).HasDefaultValueSql("'5.00'");

            entity.Property(e => e.VentaProducto).HasMaxLength(1).HasDefaultValueSql("'1'").HasComment("Es un Item para Venta;chk;true;true;Administracion;180;left");

            entity.Property(e => e.VentajasProducto).HasColumnType("text");

            entity.Property(e => e.VerificarPlazoLineasProducto).HasColumnType("int(1)");

            entity.Property(e => e.VisualizarDescuentoProducto).HasColumnType("int(1)");

        }
    }
}
