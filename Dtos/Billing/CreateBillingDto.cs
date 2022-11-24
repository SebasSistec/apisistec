using apisistec.Entities;

namespace apisistec.Dtos.Billing
{
    public class CreateBillingDto : BillingDto
    {
        public BillingParams Params { get; set; }
    }
}
