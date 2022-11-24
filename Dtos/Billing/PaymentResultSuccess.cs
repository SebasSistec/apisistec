namespace apisistec.Dtos.Billing
{
    public class PaymentResultSuccess
    {
        public string TransactionId { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string? Reference { get; set; } = string.Empty;
        public object AditionalData { get; set; } = new { data = "test" };
        public string ClientTransactionId { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string ClientId { get; set; } = string.Empty;
        public int ClientIdentificationType { get; set; } = 1;
        public string ClientName { get; set; } = string.Empty;
        public string ClientLastName { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public string ClientAddress { get; set; } = string.Empty;
        public string ClientMail { get; set; } = string.Empty;
        public int VoucherNumber { get; set; } = 0;
        public decimal Value { get; set; } = decimal.Zero;
        public decimal TotalValue { get; set; } = decimal.Zero;
        public string? AuthCode { get; set; } = string.Empty;
        public string? BatchNo { get; set; } = string.Empty;
        public string? ReferenceNo { get; set; } = string.Empty;
        public string Card { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public string Last4Digits { get; set; } = string.Empty;
    }
}
