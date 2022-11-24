namespace apisistec.Dtos.Plans
{
    public class ContractsResponseDto
    {
        public Guid Id { get; set; }
        public decimal SubtotalZero { get; set; }
        public decimal SubtotalIva { get; set; }
        public decimal IvaValue { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EDocsCount { get; set; }
        public string InvoiceNum { get; set; }
        public int Status { get; set; } = 1;
    }
}
