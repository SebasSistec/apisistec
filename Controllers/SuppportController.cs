using apisistec.Constants;
using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Support;
using apisistec.Entities;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/support")]
    [ApiController]
    public class SuppportController : ControllerBase
    {
        private ISupportService _supportService;
        private IMediaService _mediaService;
        private DataContext _context;
        DefaultResponses response = new();

        public SuppportController(ISupportService supportService, DataContext context, IMediaService mediaService)
        {
            _context = context;
            _supportService = supportService;
            _mediaService = mediaService;
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

            return Ok(response.SuccessResponse("Ok", issue));
        }

        [HttpGet("by-user")]
        [Authorize]
        public IActionResult CreateIssue([FromQuery] QueryParams qParams)
        {
            PaginationDto<SupportDto> issues = _supportService.GetByUser(qParams);
            return Ok(response.SuccessResponse("Ok", issues));
        }

        [HttpPut("state")]
        [Authorize]
        public IActionResult UpdateDetailStateDto([FromBody] UpdateDetailTimingDto detail)
        {
            UpdateDetailTimingDto issue = _supportService.UpdateSupportDetail(detail);
            return Ok(response.SuccessResponse("Ok", issue));
        }
    }
}
