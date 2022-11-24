using apisistec.Dtos.Billing;
using apisistec.Dtos.Plans;
using apisistec.Entities;
using Models;

namespace apisistec.Interfaces
{
    public interface IContractedPlansService
    {
        List<ContractsResponseDto> GetByUser(Guid userId);
        ContractedPlans Save(PlanHeader plan, PaymentDto payment, Guid userId, string? clientId = "", string? billingId = "");
    }
}
