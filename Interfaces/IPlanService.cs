using apisistec.Dtos.Plans;

namespace apisistec.Interfaces
{
    public interface IPlanService
    {
        List<PlanDto> AllEnabled();
    }
}
