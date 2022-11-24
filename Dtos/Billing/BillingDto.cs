namespace apisistec.Dtos.Billing
{
    public class BillingDto
    {
        public Guid PlanId { get; set; }
        public CustomerDto Customer { get; set; }
        public PaymentDto Payment { get; set; }
        public List<Item> Items { get; set; }
    }
}
