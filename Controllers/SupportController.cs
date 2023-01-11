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

        [HttpGet("timings/{detailId}")]
        public IActionResult GetTimings(Guid detailId)
        {
            List<IssueTimingDto> timings = _supportService.GetTiming(detailId);
            return response.SuccessResponse("Ok", timings);
        }

        [HttpPost("reasign-support")]
        [Authorize]
        public IActionResult ReasignSupport([FromBody] ReasignSupportDto data)
        {
            _supportService.ReasignSupport(data);
            return response.SuccessResponse("Realizado", data);
        }

        [HttpGet("started-support")]
        [Authorize]
        public IActionResult GetStartedSupport()
        {
            SupportDto? support = _supportService.GetStartedSupport();
            return response.SuccessResponse("Realizado", support);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var a = Environment.GetEnvironmentVariable("TEMP");
            var b = Environment.GetEnvironmentVariable("TMP");
            var c = EnvironmentVariableTarget.User;
            var d = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User);
            var e = Environment.OSVersion.Platform;
            var f = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var g = Environment.GetEnvironmentVariable("HOME");
            var h = Environment.OSVersion.Platform == PlatformID.Win32NT;
            return Ok(new { a, b, c, d, e, f, g, h });
        }

        
    }
}
