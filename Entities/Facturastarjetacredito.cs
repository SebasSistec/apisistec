namespace Models
{
    public partial class Facturastarjetacredito
    {
        public string CodigoFacturaTarjetaCredito { get; set; } = null!;
        public string FacturasCabeceraFacturaTarjetaCredito { get; set; } = null!;
        public string TajetasCreditoFacturaTarjetaCredito { get; set; } = "1";
        public string TiposFinanciamientosFacturaTarjetaCredito { get; set; } = string.Empty;
        public string NumeroTarjetaFacturaTarjetaCredito { get; set; } = null!;
        public double ValorTarjetaFacturaTarjetaCredito { get; set; }
        public string ReferenciaFacturaTarjetaCredito { get; set; } = null!;
        public string LoteFacturaTarjetaCredito { get; set; } = null!;
        /// <summary>
        /// 0 = No Depositado
        /// 1 = Depositado
        /// </summary>
        public string PagadaFacturaTarjetaCredito { get; set; } = "0";
        public string DepositosTarjetaCreditoFacturaTarjetaCredito { get; set; } = string.Empty;
        public string AnuladoFacturaTarjetaCredito { get; set; } = "0";
        public string TipoCuentaBancariaFacturaTarjetaCredito { get; set; } = "T";
        public string CodigoMovimiento { get; set; } = string.Empty;
    }
}
