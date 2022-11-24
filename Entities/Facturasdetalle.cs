namespace Models
{
    public partial class Facturasdetalle
    {
        public string CodigoFacturaDetalle { get; set; } = null!; // guid
        public string FacturasCabeceraFacturaDetalle { get; set; } = null!; // 
        public string EmpresasFacturaDetalle { get; set; } = null!; // 
        public string SucursalesFacturaDetalle { get; set; } = null!; //
        public string LocalFacturaDetalle { get; set; } = null!; //
        public string PuntoFacturaDetalle { get; set; } = null!; //
        public string NumeroCabeceraFacturaDetalle { get; set; } = null!; //
        public string TiposDocumentoFacturaDetalle { get; set; } = null!; //
        public DateTime FechaFacturaDetalle { get; set; } //
        public string EmpleadosCreaFacturaDetalle { get; set; } = null!; //
        public string VendedoresFacturaDetalle { get; set; } = null!; //
        public string BodegasOrigenFacturaDetalle { get; set; } = null!; //
        public string ProductosFacturaDetalle { get; set; } = null!; // FK producto
        public string CodigoPadreFacturaDetalle { get; set; } = string.Empty;
        public string CuentasVentaFacturaDetalle { get; set; } = null!; // Fk producto - CuentasContabilidadVentaProducto
        public string CuentasCompraFacturaDetalle { get; set; } = null!; //  fk producto -  CuentasContabilidadCompraProducto
        public string CuentasCostoFacturaDetalle { get; set; } = null!; // fk producto -  CuentasContabilidadCostoProducto
        public decimal CantidadFacturaDetalle { get; set; } = decimal.One;
        public decimal BonificacionFacturaDetalle { get; set; } = decimal.Zero;
        public decimal PrecioVentaFacturaDetalle { get; set; } // sin iva
        public decimal PrecioNegociadoFacturaDetalle { get; set; } // sin iva
        public decimal PrecioMarcadoFacturaDetalle { get; set; } // sin iva
        public decimal DescuentoFacturaDetalle { get; set; } = decimal.Zero;
        public decimal PorcentajeDescuentoFacturaDetalle { get; set; } = decimal.Zero;
        public decimal CostoProductoFacturaDetalle { get; set; } = decimal.Zero;
        public decimal CostoIsdproductoFacturaDetalle { get; set; } = decimal.Zero;
        public decimal IvaProductoFacturaDetalle { get; set; } // Fk producto
        public string TipoIcesFacturaDetalle { get; set; } = "0";
        public decimal ProcentajeIceFacturaDetalle { get; set; } = decimal.Zero;
        public string PromocionFacturaDetalle { get; set; } = "0";
        public string ComboProductoFacturaDetalle { get; set; } = "0";
        public string CodigosComboFacturaDetalle { get; set; } = string.Empty;
        public string ObservacionFacturaDetalle { get; set; } = string.Empty;
        public decimal PrecioVentaPublicoFacturaDetalle { get; set; } // precio sin iva
        public decimal PorcentajeDescuentoPvpfacturaDetalle { get; set; } = decimal.Zero;
        public decimal PorcentajeDescuentoAdicionalFacturaDetalle { get; set; } = decimal.Zero;
        public string OrdenesPedidoDetalleFacturaDetalle { get; set; } = string.Empty;
        public string PromocionAplicaFacturaDetalle { get; set; } = "0";
        public int GrupoProductoFacturaDetalle { get; set; } = 1;
        public string TipoProductoFacturaDetalle { get; set; } = "N";
        public string DescripcionProductoFacturaDetalle { get; set; } = null!; // Fk product descripcion
        public int ProductoDadoDeBaja { get; set; } = 0;
        public int PosicionFacturaDetalle { get; set; } = 0;
        public DateTime FechaRegistroFacturaDetalle { get; set; } = DateTime.Now;
        public DateTime FechaAnulacionFacturaDetalle { get; set; } = DateTime.Now;
        public string UsuariosFacturaDetalle { get; set; } = null!; // FK empleados username

        public Facturascabecera Billing { get; set; }
    }
}
