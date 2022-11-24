using apisistec.Entities;

namespace Models
{
    /// <summary>
    /// PuntosFacura
    /// </summary>
    public partial class Puntosfactura
    {
        /// <summary>
        /// Codigo Punto Factura;text;true;false;Datos;180;left
        /// </summary>
        public string CodigoPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Empresa;combo;true;false;Datos;180;left;Select CodigoEmpresa,NombreEmpresa from Empresas
        /// </summary>
        public string EmpresasPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Sucursal;combo;true;false;Datos;180;left;Select CodigoSucursal,NombreSucursal from Sucursales
        /// </summary>
        public string SucursalesPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Local Factura;text;true;true;Datos;180;left
        /// </summary>
        public string LocalPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Punto Factura;text;true;true;Datos;180;left
        /// </summary>
        public string PuntoPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Factura Actual;text;true;true;Datos;180;left
        /// </summary>
        public long? FacturaPuntoFactura { get; set; }
        /// <summary>
        /// Autorizacion Factura;text;true;true;Datos;180;left
        /// </summary>
        public string AutorizacionFacturaPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Caducidad Factura;cal;true;true;Datos;180;left
        /// </summary>
        public DateTime CaducidadFacturaPuntoFactura { get; set; }
        /// <summary>
        /// Nota de Venta Actual;text;true;true;Datos;180;left
        /// </summary>
        public long NotaVentaPuntoFactura { get; set; }
        /// <summary>
        /// Autorizacion Nota de Venta ;text;true;true;Datos;180;left
        /// </summary>
        public string AutorizacionNotaVentaPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Caducidad Nota de Venta;cal;true;true;Datos;180;left
        /// </summary>
        public DateTime CaducidadNotaVentaPuntoFactura { get; set; }
        /// <summary>
        /// Liquidacion de Compra Actual;text;true;true;Datos;180;left
        /// </summary>
        public long LiquidacionPuntoFactura { get; set; }
        /// <summary>
        /// Autorizacion Liquidacion de Compra;text;true;true;Datos;180;left
        /// </summary>
        public string AutorizacionLiquidacionPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Caducidad Liquidacion de Compra;cal;true;true;Datos;180;left
        /// </summary>
        public DateTime CaducidadLiquidacionPuntoFactura { get; set; }
        /// <summary>
        /// Nota de Credito Actual;text;true;true;Datos;180;left
        /// </summary>
        public long NotaCreditoPuntoFactura { get; set; }
        /// <summary>
        /// Autorizacion Nota de Credito;text;true;true;Datos;180;left
        /// </summary>
        public string AutorizacionNotaCreditoPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Caducidad Nota de Credito;cal;true;true;Datos;180;left
        /// </summary>
        public DateTime CaducidadNotaCreditoPuntoFactura { get; set; }
        /// <summary>
        /// Retencion Actual;text;true;true;Datos;180;left
        /// </summary>
        public long RetencionPuntoFactura { get; set; }
        /// <summary>
        /// Autorizacion Retencion;text;true;true;Datos;180;left
        /// </summary>
        public string AutorizacionRetencionPuntoFactura { get; set; } = null!;
        /// <summary>
        /// Caducidad Retencion;cal;true;true;Datos;180;left
        /// </summary>
        public DateTime CaducidadRetencionPuntoFactura { get; set; }
        /// <summary>
        /// Caducidad Retencion;cal;false;false;Datos;180;left
        /// </summary>
        public double OrdenPedidoPuntoFactura { get; set; }
        /// <summary>
        /// Caducidad Retencion;cal;false;false;Datos;180;left
        /// </summary>
        public double OrdenCompraPuntoFactura { get; set; }
        /// <summary>
        /// Caducidad Retencion;cal;false;false;Datos;180;left
        /// </summary>
        public double OrdenImportacionPuntoFactura { get; set; }
        /// <summary>
        /// Caducidad Retencion;cal;false;false;Datos;180;left
        /// </summary>
        public double OrdenVentaPuntoFactura { get; set; }
        /// <summary>
        /// Caducidad Retencion;cal;false;false;Datos;180;left
        /// </summary>
        public double OrdenServicioTecnicoPuntoFactura { get; set; }
        public double ServicioLaboratorioPuntoFactura { get; set; }
        public double NumeroPagoPuntoFactura { get; set; }
        public double NumeroPagoClientePuntoFactura { get; set; }
        public long OrdenProduccionPuntoFactura { get; set; }
        public double DepositoBancoPuntoFactura { get; set; }
        public double ChequeProtestadoPuntoFactura { get; set; }
        public double FactoringPuntoFactura { get; set; }
        public long NumeroGuiaPuntoFactura { get; set; }
        public string AutorizacionFacturaPunto { get; set; } = null!;
        public DateTime FechaGuiaPuntoFactura { get; set; }
        public long NumuroGuiaInternaPuntoFactura { get; set; }
        public long NumeroDespiecePuntoFactura { get; set; }
        public double EmisonChequePuntoFactura { get; set; }
        public double NumeroPagoProveedorPuntoFactura { get; set; }
        public long CompraActualPuntoFactura { get; set; }
        public long ChequeGarantiaActualPuntoFactura { get; set; }
        public double NumeroAnticipoProveedorPuntoFactura { get; set; }
        public int NumeroMovimientoBancoPuntoFactura { get; set; }
        public int NumeroTransferenciaImportacionPuntoFactura { get; set; }
        public double? NumeroCuentaImportacionPuntoFactura { get; set; }
        public string TipoPuntoFactura { get; set; } = null!;
        public string UsuariosPuntoFactura { get; set; } = null!;
        public string CuentaEfectivoPuntoFactura { get; set; } = null!;
        public string CuentaChequePuntoFactura { get; set; } = null!;
        public string CuentaTarjetaCreditoPuntoFactura { get; set; } = null!;
        public string CuentaCreditoPuntoFactura { get; set; } = null!;
        public string CuentaCreditoRelacionadosPuntoFactura { get; set; } = null!;
        public double NumeroRetencionPuntoFactura { get; set; }
        public string NumeroFacturaInicioPuntoFactura { get; set; } = null!;
        public string NumeroFacturaFinPuntoFactura { get; set; } = null!;
        public string NumeroGuiaInicioPuntoFactura { get; set; } = null!;
        public string NumeroGuiaFinPuntoFactura { get; set; } = null!;
        public string NumeroNotaCreditoInicioPuntoFactura { get; set; } = null!;
        public string NumeroNotaCreditoFinPuntoFactura { get; set; } = null!;
        public string NumeroRetencionInicioPuntoFactura { get; set; } = null!;
        public string NumeroRetencionFinPuntoFactura { get; set; } = null!;
        public string PerfilesDocsPendientesPuntoFactura { get; set; } = null!;
        public string BodegaDefectoPuntoFactura { get; set; } = null!;
        public string RealizarSeguimientoPuntoFactura { get; set; } = null!;
        public string RealizarImpresionPuntoFactura { get; set; } = null!;
        public string NumeroAjusteInventarioPuntoFactura { get; set; } = null!;
        public string GenerarGuiaPuntoFactura { get; set; } = null!;
        public long SecuenciaNotaCreditoCompraPuntoFactura { get; set; }
        public long SecuenciaNotaCreditoGastoPuntoFactura { get; set; }
        public long SecuenciaNotaCreditoImportacionPuntoFactura { get; set; }
        public string ModelosImpresionFacturaPuntoFactura { get; set; } = null!;
        public string ModelosImpresionNotaCreditoPuntoFactura { get; set; } = null!;
        public string ModelosImpresionGuiaRemisionPuntoFactura { get; set; } = null!;
        public string ModelosImpresionRetencionPuntoFactura { get; set; } = null!;
        public string ModelosImpresionPagoPuntoFactura { get; set; } = null!;
        public string CuentaContableDescuadrePuntoFactura { get; set; } = null!;
        public string OrdenGastoPuntoFactura { get; set; } = null!;
        public int SecuenciaAnticiposClientesPuntoFactura { get; set; }
        public string ItinerantePuntoFactura { get; set; } = null!;
        public string PrefijoItinerantePuntoFactura { get; set; } = null!;
        public string DireccionItinerantePuntoFactura { get; set; } = null!;
        public int SecuenciaOrdenServicioTecnicoPuntoFactura { get; set; }
        public string DisponibleFacturacionBloquePuntoFactura { get; set; } = null!;
        public int HabilitadoPuntoFactura { get; set; }
        public int SeleccionaVendedorPuntoFactura { get; set; }
        public int AgregarProductosEnBloqueBuscador { get; set; }
        public string DefectoRetencionPuntoFactura { get; set; } = null!;
        public string TidRecargasPuntoFactura { get; set; } = null!;
        public string CajeroRecargasPuntoFactura { get; set; } = null!;
        public string ClaveRecargasPuntoFactura { get; set; } = null!;
        public int SecuenciaAtorizacionRecargasPuntoFactura { get; set; }
        public int SecuenciaReferenciaRecargasPuntoFactura { get; set; }
        public int HabilitadoServicioRecargasPuntoFactura { get; set; }
        public int NumeroDepositoBancoCaja { get; set; }
        public int FacturaUsuarioAperturaCajaPuntoFactura { get; set; }
        public int EsPuntoServicioTecnicoPuntoFactura { get; set; }
        public string BodegaOrigenSolicitudTransferenciaServicioTecnicoPuntoFactura { get; set; } = null!;
        public int SecuenciaDespachosPuntoFactura { get; set; }
        public int NegociablePuntoFactura { get; set; }
        public List<BillingParams> BillingParams { get; set; } = new();
    }
}
