namespace apisistec.Entities
{
    /// <summary>
    /// Cliente;NombreCliente,ApellidoCliente;NombreComercialCliente
    /// </summary>
    public partial class Cliente
    {
        public string CodigoCliente { get; set; } = string.Empty; //PENDING CHANGE PRODUCTION clientes & citasmedicas & auditoriaclientes FK TO VARCHAR(36)
        public string CodigoSecuencialCliente { get; set; } = string.Empty;
        public string TiposIdentificacionCliente { get; set; } = null!;
        public string NumeroIdentificacionCliente { get; set; } = null!;
        public string NombreComercialCliente { get; set; } = string.Empty;
        public string PrioridadNombreComercialCliente { get; set; } = "0";
        public string CedulaRepresentanteLegalCliente { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = null!;
        public string ApellidoCliente { get; set; } = null!;
        public string CedulaConyugeCliente { get; set; } = string.Empty;
        public string NombreConyugeCliente { get; set; } = string.Empty;
        public string ApellidoConyugeCliente { get; set; } = string.Empty;
        public DateTime FechaNacimientoConyugeCliente { get; set; }
        public string DireccionUnoCliente { get; set; } = null!;
        public string DireccionDosCliente { get; set; } = string.Empty;
        public string SectorDireccionCliente { get; set; } = string.Empty;
        public string TelefonoUnoCliente { get; set; } = null!;
        public string TelefonoDosCliente { get; set; } = string.Empty;
        public string TelefonoTresCliente { get; set; } = string.Empty;
        public string TelefonoCuatroCliente { get; set; } = string.Empty;
        public string TelefonoCincoCliente { get; set; } = string.Empty;
        public string TelefonoSeisCliente { get; set; } = string.Empty;
        public string MailCliente { get; set; } = null!;
        public string WebCliente { get; set; } = string.Empty;
        /// <summary>
        /// M MASCULINO F FEMENINO
        /// </summary>
        public string SexoCliente { get; set; } = "M";
        /// <summary>
        /// S SOLTERO C CASADO V VIUDO D DIVORCIADO U UNION LIBRE
        /// </summary>
        public string EstadoCivilCliente { get; set; } = "S";
        public DateTime FechaNacimientoCliente { get; set; }
        public string ObservacionCliente { get; set; } = string.Empty;
        public string SolicitudesCreditoCliente { get; set; } = "";
        public string ExigirDocumentosCliente { get; set; } = "0";
        public string CuentasContabilidadCliente { get; set; } = string.Empty;
        public string TiposClienteCliente { get; set; } = "0";
        public string TiposNegocioCliente { get; set; } = "0";
        public string TiposNegocioSecundarioCliente { get; set; } = "0";
        public string TamanioNegociosCliente { get; set; } = "0";
        public string EstatalCliente { get; set; } = "0";
        public string RelacionCliente { get; set; } = "0";
        public string CiudadesCliente { get; set; } = "0";
        public string ZonasCliente { get; set; } = "0";
        public string TitulosCliente { get; set; } = "0";
        public string ListasPrecioCliente { get; set; } = "0";
        public string ListasPrecioMaximaCliente { get; set; } = string.Empty;
        public string ContactoCliente { get; set; } = "0";
        public string ContribuyenteEspecialCliente { get; set; } = "0";
        public string TransportesCliente { get; set; } = "0";
        /// <summary>
        /// 0
        /// </summary>
        public string AplicaPromocionCliente { get; set; } = "0";
        /// <summary>
        /// Permite determinar si el cliente emite retenciones
        /// </summary>
        public string EmiteRetencionCliente { get; set; } = "0";
        public string CalificacionTipoCliente { get; set; } = "E";
        public string CalificacionPagoCliente { get; set; } = "0";
        public string CalificacionUtilidadCliente { get; set; } = "0";
        public string TiposNegociosCalificacionCliente { get; set; } = "1";
        public string UsuariosCliente { get; set; } = string.Empty;
        public string AgrocalidadCliente { get; set; } = "0";
        public string OmitirCupoCalificacionCliente { get; set; } = "0";
        public DateTime FechaRegistroCupoCalificacionCliente { get; set; }
        public DateTime FechaHastaCupoCalificacionCliente { get; set; }
        public string OmitirDescuentoCliente { get; set; } = string.Empty;
        public string EmpleadoEmpresaCliente { get; set; } = "0";
        public string DinardapCliente { get; set; } = "1";
        /// <summary>
        /// indica si el cliente esta relacionado con la empresa.
        /// </summary>
        public string RelacionadoEmpresaCliente { get; set; } = "0";
        public string BodegasCliente { get; set; } = "0";
        public string Tiposclientesegurocliente { get; set; } = "1";
        public string PagaChequeCliente { get; set; } = "0";
        public string PagaChequePosfechadoCliente { get; set; } = "0";
        public string PuedeTenerConsignacionCliente { get; set; } = "0";
        public double MontoMinimoCreditoCliente { get; set; } = 0;
        public decimal MontoMaximoConsignacionCliente { get; set; } = 0;
        public int DiasDemoraEntregaCliente { get; set; } = 1;
        public string RutasEntregasCliente { get; set; } = string.Empty;
        public string EmailDespahosCliente { get; set; } = string.Empty;
        public string TiposClienteCarteraCliente { get; set; } = "0";
        public string UsuariosModificaCliente { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty; //Campo nuevo
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public List<ContractedPlans> ContractedPlans { get; set; } = new();
        public List<Issues> issues { get; set; } = new();
    }
}
