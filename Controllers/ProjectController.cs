using apisistec.Dtos;
using apisistec.Dtos.Project;
using apisistec.Entities;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        DefaultResponses response = new();

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Search([FromQuery] QueryParams qParams, string? companyId)
        {
            PaginationDto<Projects> find = _projectService.GetProjectsPerCompany(qParams, companyId);
            return response.SuccessResponse("Ok", find);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProjectRequestDto data)
        {
            _projectService.Create(data);
            return response.SuccessResponse("Ok", data);
        }

        [HttpGet("module")]
        public IActionResult SearchModules([FromQuery] QueryParams qParams)
        {
            PaginationDto<Modules> find = _projectService.GetModules(qParams);
            return response.SuccessResponse("Ok", find);
        }

        [HttpPost("module")]
        public IActionResult CreateModule([FromBody] ProjectOrModuleDto data)
        {
            _projectService.CreateModule(data);
            return response.SuccessResponse("Ok", data);
        }
    }
}
