using apisistec.Dtos.Plans;
using apisistec.Helpers;
using apisistec.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/package-plan")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private IPlanService _planService;

        DefaultResponses response = new();
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public IActionResult All()
        {
            List<PlanDto> planList = new();
            planList = _planService.AllEnabled();
            return response.SuccessResponse("Ok", planList);
        }
    }
}
