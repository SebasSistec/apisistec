using apisistec.Enums;
using Models;

namespace apisistec.Entities
{
    public class ContractedPlans
    {
        public Guid Id { get; set; }
        public decimal TotalValue { get; set; }
        public decimal SubtotalIva { get; set; }
        public decimal SubtotalZero { get; set; }
        public decimal IvaValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Lat { get; set; } = string.Empty;
        public string Lng { get; set; } = string.Empty;
        public string ProvinceInec { get; set; } = string.Empty;
        public string CantonInec { get; set; } = string.Empty;
        public int EDocsCount { get; set; }
        public PlanTypeEnum Type { get; set; }
        public DateTime EndDate {  get; set; }
        public int RucQty { get; set; }
        public PaymentState PaymentState { get; set; }
        public string? ClientId { get; set; }
        public string? BillId { get; set; }
        public Guid PlanId { get; set; }
        public Guid UserId { get; set; }

        //FK
        public Cliente Client { get; set; }
        public Facturascabecera Billing { get; set; }
        public PlanHeader Plan { get; set; }
        public Users User { get; set; }
    }
}
