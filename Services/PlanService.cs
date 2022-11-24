using apisistec.Context;
using apisistec.Dtos.Plans;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apisistec.Services
{
    public class PlanService : IPlanService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public PlanService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PlanDto> AllEnabled()
        {
            List<PlanHeader> planHeader = _context.PlanHeader
                .Include(x => x.Product)
                .Include(x => x.PlanHeaderXDetail.OrderBy(x => x.Order))
                .ThenInclude(x => x.Detail)
                .Where(x =>
                    x.State == StateEnum.ENABLED
                    && x.EndAt >= DateTime.Now)
                .OrderBy(x => x.Price)
                .ToList();

            List<PlanDto> plans = _mapper.Map<List<PlanDto>>(planHeader);
            return plans;
        }
    }
}
