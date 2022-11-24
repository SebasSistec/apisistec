using apisistec.Enums;
using Models;

namespace apisistec.Entities
{
    public class PlanHeader
    {
        public PlanHeader()
        {
            PlanHeaderXDetail = new List<PlanHeaderXDetail>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public StateEnum State { get; set; }
        public decimal Price { get; set; }
        public decimal PastPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal PastDiscountPercent { get; set; }
        public int TransacctionQty { get; set; }
        public int RucQty { get; set; }
        public PlanTypeEnum Type { get; set; }
        public int MonthsAvailables { get; set; }
        public string ProductId { get; set; }

        public Producto Product { get; set; }
        public List<PlanHeaderXDetail> PlanHeaderXDetail { get; set; }
        public List<ContractedPlans> ContractedPlans { get; set; } = new();
    }
}
