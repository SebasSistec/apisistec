using apisistec.Dtos.Billing;
using apisistec.Entities;
using Models;

namespace apisistec.Interfaces
{
    public interface IBillingService
    {
        void Billing(BillingDto billData, string clientId, out Facturascabecera billingSaved);
        BillingParams GetBillingParams();
    }
}
