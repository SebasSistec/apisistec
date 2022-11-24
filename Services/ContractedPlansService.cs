using apisistec.Context;
using apisistec.Dtos.Billing;
using apisistec.Dtos.Plans;
using apisistec.Entities;
using apisistec.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apisistec.Services
{
    public class ContractedPlansService : IContractedPlansService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ContractedPlansService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ContractsResponseDto> GetByUser(Guid userId)
        {
            List<ContractedPlans> contracts = _context.ContractedPlans
                                        .Include(x => x.Plan)
                                        .Include(x => x.User)
                                        .Include(x => x.Billing)
                                        .Where(x => x.UserId == userId)
                                        .OrderByDescending(x => x.CreatedAt)
                                        .ToList();
            return _mapper.Map<List<ContractsResponseDto>>(contracts);
        }

        public ContractedPlans Save(PlanHeader plan, PaymentDto payment, Guid userId, string? clientId = "", string? billingId = "")
        {
            decimal value = payment.TotalIvaValue + payment.TotalBaseIva + payment.TotalBaseZero;
            ContractedPlans contract = new()
            {
                Id = Guid.NewGuid(),
                TotalValue = value,
                SubtotalIva = payment.TotalBaseIva,
                SubtotalZero = payment.TotalBaseZero,
                IvaValue = payment.TotalIvaValue,
                CreatedAt = DateTime.Now,
                PlanId = plan.Id,
                UserId = userId,
                ClientId = clientId,
                BillId = billingId,
                EDocsCount = plan.TransacctionQty,
                Type = plan.Type,
                EndDate = DateTime.Now.AddMonths(plan.MonthsAvailables),
                RucQty = plan.RucQty,
                PaymentState = payment.PaymentState
            };
            return contract;
        }
    }
}
