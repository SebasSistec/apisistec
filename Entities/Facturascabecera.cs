using apisistec.Entities;

namespace Models
{
    public partial class Facturascabecera
    {
        public string CodigoFacturaCabecera { get; set; } = string.Empty;
        public string IdTransaccionFacturaCabecera { get; set; } = string.Empty;
        public string EmpresasFacturaCabecera { get; set; } = null!;
        public string SucursalesFacturaCabecera { get; set; } = null!;
        public string LocalFacturaCabecera { get; set; } = null!;
        public string PuntoFacturaCabecera { get; set; } = null!;
        public string ContratoCabeceraFacturaCabecera { get; set; } = string.Empty;
        public string NumeroFacturaCabecera { get; set; } = null!;
        public string TiposDocumentoFacturaCabecera { get; set; } = "FV";
        public string EmpleadosCreaFacturaCabecera { get; set; } = null!; //FK Employee
        public string VendedoresFacturaCabecera { get; set; } = string.Empty;
        public DateTime FechaFacturaCabecera { get; set; }
        public string ClientesFacturaCabecera { get; set; } = string.Empty;
        public string DireccionFacturaCabecera { get; set; } = null!;
        public string LocalesClienteFacturaCabecera { get; set; } = string.Empty;
        public string TiposPagoFacturaCabecera { get; set; } = null!;
        public string CuentasEfectivoFacturaCabecera { get; set; } = "0";
        public string ListasPrecioFacturaCabecera { get; set; } = "0";
        public string AutorizacionFacturaCabecera { get; set; } = string.Empty;
        public DateTime CaducidadFacturaCabecera { get; set; }
        public decimal SubTotalFacturaCabecera { get; set; } = decimal.Zero;
        public decimal SubTotal0FacturaCabecera { get; set; } = decimal.Zero;
        public decimal SubTotalIceFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorDescuentoFacturaCabecera { get; set; } = decimal.Zero;
        public decimal PorcentajeDescuentoFacturaCabecera { get; set; } = decimal.Zero;
        public decimal BaseIvaFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorIvaFacturaCabecera { get; set; } = decimal.Zero;
        public decimal PorcentajeIvaFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorIceFacturaCabecera { get; set; } = decimal.Zero;
        public decimal PorcentajeIceFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorServicioFacturaCabecera { get; set; } = decimal.Zero;
        public decimal PorcentajeServicioFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorTransporteFacturaCabecera { get; set; } = decimal.Zero;
        public decimal PorcentajeTransporteFacturaCabecera { get; set; } = decimal.Zero;
        public decimal OtroImpuestoFacturaCabecera { get; set; } = decimal.Zero;
        public string BodegasOrigenFacturaCabecera { get; set; } = null!;
        public decimal AsientosCabeceraFacturaCabecera { get; set; } = decimal.Zero; //call AsientoVentasNuevo PENDING CHANGE VarCodigoCliente(36)
        public string ObservacionesFacturaCabecera { get; set; } = null!;
        public string ObservacionesClienteFacturaCabecera { get; set; } = string.Empty;
        public string ObservacionesAnulacionFacturaCabecera { get; set; } = string.Empty;
        public string ObservacionesAutorizadoFacturaCabecera { get; set; } = string.Empty;
        public string ObservacionGuiaFacturaCabecera { get; set; } = string.Empty;
        /// <summary>
        /// Alamcena el transpotista
        /// </summary>
        public string TransportistasFacturaCabecera { get; set; } = string.Empty;
        public string LocalGuiaFacturaCabecera { get; set; } = string.Empty;
        public string PuntoGuiaFacturaCabecera { get; set; } = string.Empty;
        /// <summary>
        /// Almacena el numero de guia de envio de mercaderia
        /// </summary>
        public string NumeroGuiaFacturaCabecera { get; set; } = string.Empty;
        public string AnuladoFacturaCabecera { get; set; } = "0";
        /// <summary>
        /// Indica si se aplico la promocion en la factura
        /// </summary>
        public string AplicoPromocionFacturaCabecera { get; set; } = "0";
        public decimal BonoGeneradoFacturaCabecera { get; set; } = decimal.Zero;
        public decimal BonoAplicadoFacturaCabecera { get; set; } = decimal.Zero;
        public string ImpresionFacturaCabecera { get; set; } = "0";
        public string ChequesProtestadoFacturaCabecera { get; set; } = "0";
        public DateTime FechaRegistroFacturaCabecera { get; set; }
        public DateTime FechaAnulacionFacturaCabecera { get; set; }
        public DateTime FechaImpresionFacturaCabecera { get; set; }
        public string UsuariosRegistroFacturaCabecera { get; set; } = null!;
        public string UsuariosAnuloFacturaCabecera { get; set; } = string.Empty;
        public string UsuariosImpresionFacturaCabecera { get; set; } = string.Empty;
        public decimal ValorTransporte0FacturaCabecera { get; set; } = decimal.Zero;
        public decimal PorcentajeTransporte0FacturaCabecera { get; set; } = decimal.Zero;
        public string FacturaEnviadaFacturaCabecera { get; set; } = "0";
        public string TipoEmisionFacturaCabecera { get; set; } = null!; //FK params - punto fact
        public string EstadoElectronicoFacturaCabecera { get; set; } = string.Empty;
        public string NumeroAutorizacionElectronicoFacturaCabecera { get; set; } = string.Empty;
        public string FechaAutorizacionElectronicoFacturaCabecera { get; set; } = string.Empty;
        /// <summary>
        /// clave de acceso generada por el sistema wise
        /// </summary>
        public string ClaveAccesoFacturaCabecera { get; set; } = string.Empty;
        public decimal ValorDescuentoItemsFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorDescuentoItemsGrabaFacturaCabecera { get; set; } = decimal.Zero;
        public decimal ValorDescuentoItems0FacturaCabecera { get; set; } = decimal.Zero;
        public string OmitirDinardapFacturaCabecera { get; set; } = "0";
        public string IpAnulaFacturaCabecera { get; set; } = string.Empty;
        public string ServicioTecnicoFacturaCabecera { get; set; } = "0";
        public string TiposPagoSriFacturaCabecera { get; set; } = "19";
        public double ValorDescuento0FacturaCabecera { get; set; } = 0;
        public decimal PorcentajeDescuento0FacturaCabecera { get; set; } = decimal.Zero;
        public int CarpetaAnuladoFacturaCabecera { get; set; } = 0;
        public string MotivosFacturaCabecera { get; set; } = "0";
        public string PlacaTransporteFacturaCabecera { get; set; } = string.Empty;
        public string TipoEmisionGuiaFacturaCabecera { get; set; } = null!; //FK params - punto fact
        public string EstadoElectronicoGuiaFacturaCabecera { get; set; } = string.Empty;
        public string NumeroAutorizacionGuiaElectronicoFacturaCabecera { get; set; } = string.Empty;
        public string FechaAutorizacionGuiaElectronicoFacturaCabecera { get; set; } = string.Empty;
        public string ClaveAccesoGuiaFacturaCabecera { get; set; } = string.Empty;
        public string RutasDespachoFacturaCabecera { get; set; } = string.Empty;
        public string VentaActivoFacturaCabecera { get; set; } = "0";
        public string VentaReembolsoFacturaCabecera { get; set; } = "0";
        public string NumeroOrdenCompraFacturaCabecera { get; set; } = string.Empty;
        public string NumeroTurnoFacturaCabecera { get; set; } = string.Empty;
        public string DireccionGuiaFacturaCabecera { get; set; } = string.Empty;
        public int OmitirComisionFacturaCabecera { get; set; } = 0;
        public string? ObservacionOmitirComisionFacturaCabecera { get; set; } = string.Empty;
        public int EstadoSincronizadoFacturaCabecera { get; set; } = 0;
        public string NumeroFacturaCompleto { get; set; } = string.Empty;

        //public virtual ICollection<Facturasdetalle> Facturasdetalles { get; set; }
        public virtual Facturaspago Facturaspago { get; set; } = null!;
        public List<Facturasdetalle> BillingDetails { get; set; } = new();
        public List<ContractedPlans> ContractedPlans { get; set; } = new();
    }
}
