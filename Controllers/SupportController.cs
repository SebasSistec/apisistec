using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Support;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using apisistec.Models.Parameters.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/support")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private ISupportService _supportService;
        private DataContext _context;
        DefaultResponses response = new();

        public SupportController(ISupportService supportService, DataContext context)
        {
            _context = context;
            _supportService = supportService;
        }

        [HttpGet("token-support")]
        public IActionResult GetSupportToken([FromQuery] string userId, string companyId)
        {
            return Ok(_supportService.GetSuppportToken(userId, companyId));
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateIssue([FromBody] IssueCreateDto create)
        {
            IssueCreatedResponseDto issue = _supportService.CreateSupport(create);

            _context.SaveChanges();

            return response.SuccessResponse("Ok", issue);
        }

        [HttpGet("by-user")]
        [Authorize]
        public IActionResult CreateIssue([FromQuery] QueryParams qParams)
        {
            PaginationDto<SupportDto> issues = _supportService.GetByUser(qParams);
            return response.SuccessResponse("Ok", issues);
        }

        [HttpPut("state")]
        [Authorize]
        public IActionResult UpdateDetailStateDto([FromBody] UpdateDetailTimingDto detail)
        {
            UpdateDetailTimingDto issue = _supportService.UpdateSupportDetail(detail);
            return response.SuccessResponse("Ok", issue);
        }

        [HttpGet("report")]
        public IActionResult GetReport([FromQuery] SupportQParams qParams)
        {
            PaginationDto<SupportDto> issues = _supportService.GetWithParams(qParams);
            return response.SuccessResponse("Ok", issues);
        }
    }
}
