namespace apisistec.Dtos.Billing
{
    public class Item
    {
        public string Id { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public decimal IvaPercent { get; set; } = decimal.Zero;
        public decimal IvaValue { get; set; } = decimal.Zero;
        public decimal? IceValue { get; set; } = decimal.Zero;
        public decimal? IcePercent { get; set; } = decimal.Zero;
        public decimal? DiscountValue { get; set; } = decimal.Zero;
        public decimal? DiscountPercent { get; set; } = decimal.Zero;
    }
}
