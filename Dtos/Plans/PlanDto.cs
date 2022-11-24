using apisistec.Enums;

namespace apisistec.Dtos.Plans
{
    public class PlanDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal IvaPercent { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int TransacctionQty { get; set; }
        public int RucQty { get; set; }
        public string ProductId { get; set; }
        public PlanTypeEnum Type { get; set; }
        public int MonthsAvailables {  get; set; }
        public List<PlanDetailDto> Details { get; set; }
    }
}
