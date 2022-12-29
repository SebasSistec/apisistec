using apisistec.Dtos.Plans;
using apisistec.Helpers;
using apisistec.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    public class ContractedPlansController : ControllerBase
    {
        private IContractedPlansService _contractService;
        private IUserService _userService;

        DefaultResponses response = new();
        public ContractedPlansController(IContractedPlansService contractedPlans, IUserService userService)
        {
            _contractService = contractedPlans;
            _userService = userService;
        }

        [HttpGet("by-user")]
        [Authorize]
        public IActionResult ListByUser()
        {
            string userId = _userService.GetUserLoggedId()!;
            List<ContractsResponseDto> contractsList = _contractService.GetByUser(Guid.Parse(userId));
            return response.SuccessResponse("Ok", contractsList); ;
        }
    }
}
