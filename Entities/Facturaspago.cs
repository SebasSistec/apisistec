namespace Models
{
    public partial class Facturaspago
    {
        public string FacturasCabeceraFacturaPago { get; set; } = null!;
        public decimal EfectivoFacturapago { get; set; } = decimal.Zero;
        public decimal TarjetaFacturaPago { get; set; } = decimal.Zero;
        public decimal ChequeFacturaPago { get; set; } = decimal.Zero;
        public decimal CreditoFacturaPago { get; set; } = decimal.Zero;
        public decimal OtrosFacturaPago { get; set; } = decimal.Zero;
        public decimal AnticipoFacturaPago { get; set; } = decimal.Zero;
        public decimal CuponFacturaPago { get; set; } = decimal.Zero;

        public virtual Facturascabecera Billing { get; set; } = null!;
    }
}
