using apisistec.Enums;

namespace apisistec.Dtos.Billing
{
    public class PaymentDto
    {
        public int PaymentType { get; set; }
        public decimal TotalBaseIva { get; set; }
        public decimal TotalBaseZero { get; set; }
        public decimal TotalIvaValue { get; set; }
        public PaymentState PaymentState { get; set; }
        public PaymentResultSuccess? Result { get; set; }
    }
}
