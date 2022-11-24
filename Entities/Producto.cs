using apisistec.Entities;

namespace Models
{
    /// <summary>
    /// Producto;DescripcionProducto,Abrevia
    /// </summary>
    public partial class Producto
    {
        //public Producto()
        //{
        //    BillingParams = new();
        //}
        /// <summary>
        /// Codigo;text;true;false;Administracion;180;left
        /// </summary>
        public string CodigoProducto { get; set; } = null!;
        /// <summary>
        /// Codigo de Item;text;true;true;Administracion;180;left
        /// </summary>
        public string CodigoVentaProducto { get; set; } = null!;
        /// <summary>
        /// Codigo en Compra;text;true;true;Administracion;180;left
        /// </summary>
        public string CodigoCompraProducto { get; set; } = null!;
        /// <summary>
        /// Codigo de Barras;text;true;true;Administracion;180;left
        /// </summary>
        public string CodigoBarraProducto { get; set; } = null!;
        /// <summary>
        /// Codigo en Catalogo;text;true;true;Administracion;180;left
        /// </summary>
        public string CodigoCatalogoProducto { get; set; } = null!;
        /// <summary>
        /// Nombre-Descripcion;text;true;true;Administracion;180;left
        /// </summary>
        public string DescripcionProducto { get; set; } = null!;
        /// <summary>
        /// Descripcion Adicional;text;true;true;Administracion;180;left
        /// </summary>
        public string DescripcionAdicionalProducto { get; set; } = null!;
        /// <summary>
        /// Descripcion Corta;text;true;true;Administracion;180;left
        /// </summary>
        public string DescripcionCortaProducto { get; set; } = null!;
        public string UnidadesProducto { get; set; } = null!;
        public string LineasProducto { get; set; } = null!;
        public string CategoriasProducto { get; set; } = null!;
        public string GruposProducto { get; set; } = null!;
        public string MarcasProducto { get; set; } = null!;
        public string ColoresProducto { get; set; } = null!;
        public DateTime FechaCreacionProducto { get; set; }
        public string CuentasContabilidadCompraProducto { get; set; } = null!;
        public string CuentasContabilidadVentaProducto { get; set; } = null!;
        public string CuentasContabilidadCostoProducto { get; set; } = null!;
        public string CuentasContabilidadDevolucionProducto { get; set; } = null!;
        public string CuentasContabilidadDescuentoProducto { get; set; } = null!;
        public string CuentasContabilidadCuponProducto { get; set; } = null!;
        public string CuentasContabilidadActivoProducto { get; set; } = null!;
        public string ArancelesProducto { get; set; } = null!;
        /// <summary>
        /// Establecer como Servicio;chk;true;true;Administracion;180;left
        /// </summary>
        public string ServicioProducto { get; set; } = null!;
        /// <summary>
        /// Item con I.V.A.;chk;true;true;Administracion;180;left
        /// </summary>
        public string PagaIvaProducto { get; set; } = null!;
        public string PagaIceProducto { get; set; } = null!;
        /// <summary>
        /// Item posee Receta?;chk;true;true;Administracion;180;left
        /// </summary>
        public string RecetaProducto { get; set; } = null!;
        /// <summary>
        /// Es un Item para Venta;chk;true;true;Administracion;180;left
        /// </summary>
        public string VentaProducto { get; set; } = null!;
        /// <summary>
        /// Es parte del Activo;chk;true;true;Administracion;180;left
        /// </summary>
        public string ActivoProducto { get; set; } = null!;
        /// <summary>
        /// Requiere Ingresar Numeros de Serie;chk;true;true;Administracion;180;left
        /// </summary>
        public string SerieLoteProducto { get; set; } = null!;
        public string LoteProducto { get; set; } = null!;
        public decimal UnidadesCajaProducto { get; set; }
        /// <summary>
        /// Peso;text;true;true;Otras Consideraciones;180;left
        /// </summary>
        public decimal PesoProducto { get; set; }
        /// <summary>
        /// Alto;text;true;true;Otras Consideraciones;180;left
        /// </summary>
        public decimal AltoProducto { get; set; }
        /// <summary>
        /// Ancho;text;true;true;Otras Consideraciones;180;left
        /// </summary>
        public decimal AnchoProducto { get; set; }
        /// <summary>
        /// Ancho;text;true;true;Otras Consideraciones;180;left
        /// </summary>
        public decimal ProfundidadProducto { get; set; }
        public decimal PrecioFofproducto { get; set; }
        /// <summary>
        /// Item de Materia Prima;chk;true;true;Otras Consideraciones;180;left
        /// </summary>
        public string MateriaPrimaProducto { get; set; } = null!;
        /// <summary>
        /// Se debe controlar su Peso;chk;true;true;Otras Consideraciones;180;left
        /// </summary>
        public string ControlarPesoProducto { get; set; } = null!;
        /// <summary>
        /// Es un Repuesto;chk;true;true;Otras Consideraciones;180;left
        /// </summary>
        public string RepuestoProducto { get; set; } = null!;
        /// <summary>
        /// Es un Sustituto de otro Item;text;true;true;Otras Consideraciones;180;left
        /// </summary>
        public string SustitutoProducto { get; set; } = null!;
        /// <summary>
        /// Es un Accesorio;chk;true;true;Otras Consideraciones;180;left
        /// </summary>
        public string AccesorioProducto { get; set; } = null!;
        public string FavoritoProducto { get; set; } = null!;
        public string PromocionProducto { get; set; } = null!;
        /// <summary>
        /// Percha en Bodega;text;true;true;Otras Consideraciones;180;left
        /// </summary>
        public string PerchaProducto { get; set; } = null!;
        /// <summary>
        /// Permite saber si el producto se aplica a algun tipo de cultivo en caso de ser agroquimio
        /// </summary>
        public string CultivoProucto { get; set; } = null!;
        /// <summary>
        /// Almacena el tipo de control en el caso de ser agroquimico
        /// </summary>
        public string ControlesProducto { get; set; } = null!;
        /// <summary>
        /// Almacena la dosis del producto en el caso de ser agroquimico
        /// </summary>
        public string DosisProducto { get; set; } = null!;
        /// <summary>
        /// Almacena la frecuencia de administracion del produto en caso de ser agroquimico
        /// </summary>
        public string FrecuenciasProducto { get; set; } = null!;
        /// <summary>
        /// Verifica si el producto es un combo
        /// </summary>
        public string ComboProducto { get; set; } = null!;
        /// <summary>
        /// Establece el porcentaje de descuento en los productos del combo
        /// </summary>
        public double DescuentoComboProducto { get; set; }
        /// <summary>
        /// Verifica si se factura el combo o cada uno de los productos
        /// </summary>
        public string FacturaComboProducto { get; set; } = null!;
        public string ListasPrecioProducto { get; set; } = null!;
        public string FacturarDecimalesProducto { get; set; } = null!;
        public int SeleccionarPorcionesProducto { get; set; }
        /// <summary>
        /// Observaciones;text;true;true;Observaciones;180;left
        /// </summary>
        public string ObservacionProducto { get; set; } = null!;
        public string DatosGeneralesProducto { get; set; } = null!;
        public string VentajasProducto { get; set; } = null!;
        public string DesventajasProducto { get; set; } = null!;
        public string DatoAdicionalProducto { get; set; } = null!;
        public string ProductosTipoProducto { get; set; } = null!;
        public string ProveedoresProducto { get; set; } = null!;
        public decimal PrecioProveedorLocalProducto { get; set; }
        public decimal VariacionCostoProduccionProducto { get; set; }
        public decimal MetrajeProducto { get; set; }
        public decimal PorcentajeBonificacionProducto { get; set; }
        public decimal PorcentajeDescuentoProducto { get; set; }
        public decimal CantidadSumaBonificacionProducto { get; set; }
        public decimal SumarNumeroFilasBonificacionProducto { get; set; }
        public decimal RecargoProducto { get; set; }
        public string CalificacionProducto { get; set; } = null!;
        public string ControlarBufferProducto { get; set; } = null!;
        public string CodigoTipoPorcentajeIce { get; set; } = null!;
        public string PlanAnchoBanda { get; set; } = null!;
        public string CompresionServicio { get; set; } = null!;
        public int VerificarPlazoLineasProducto { get; set; }
        public int IngresaMotorChasisProducto { get; set; }
        public string CategoriasServicioTecnicoProducto { get; set; } = null!;
        public int TiempomedioServicioTecnicoProducto { get; set; }
        public decimal CantidadLitrosProducto { get; set; }
        public decimal GradoAlcoholicoProducto { get; set; }
        public decimal ValorXlitroAlcoholProducto { get; set; }
        public decimal ValorIcexItemProducto { get; set; }
        public string CategoriasEspecialesProducto { get; set; } = null!;
        public int GeneraOrdenServicioTecnicoProducto { get; set; }
        public string SincronizarAppProducto { get; set; } = null!;
        public string SincronizarWebProducto { get; set; } = null!;
        public string TipoExtrasProducto { get; set; } = null!;
        public decimal DescuentoProducto { get; set; }
        public int VisualizarDescuentoProducto { get; set; }
        public string EsServicioRecargasProducto { get; set; } = null!;
        public string EcommerceIdProducto { get; set; } = null!;
        public string? LineasEcommerceProducto { get; set; }
        public string? CategoriasEcommerceProducto { get; set; }
        public string? GruposEcommerceProducto { get; set; }
        public int MigarEcommerceProducto { get; set; }
        public string? GruposCaracteristicasProducto { get; set; }
        public int DeshabilitadoProducto { get; set; }
        public int DeclaraArcsaProducto { get; set; }
        public string NumeroRegistroSanitarioProducto { get; set; } = null!;
        public string NombreComercialProducto { get; set; } = null!;
        public string? CondicionesAlmacenamientoArcsaProducto { get; set; }
        public DateTime FechaVigenciaRegistroSanitarioProducto { get; set; }
        public string Anio { get; set; } = null!;
        public string Tonelaje { get; set; } = null!;
        public string PaisOrigen { get; set; } = null!;
        public string Combustible { get; set; } = null!;
        public string Cilindraje { get; set; } = null!;
        public string Capacidad { get; set; } = null!;
        public string NumeroEjes { get; set; } = null!;
        public string NumeroRuedas { get; set; } = null!;
        public string UsuariosProducto { get; set; } = null!;

        public List<BillingParams> BillingParams { get; set; } = new();
        public List<PlanHeader> PlanPackages { get; set; } = new();
        public List<EmpresasProductos> Pricing { get; set; } = new();
        public List<IssueDetails> issues { get; set; } = new();
    }
}
