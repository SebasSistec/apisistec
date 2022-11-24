using apisistec.Dtos;
using apisistec.Dtos.Employee;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        DefaultResponses response = new();

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Search([FromQuery] QueryStringParams qParams, string companyId)
        {
            PaginationDto<EmployeeDto> find = _employeeService.Find(companyId, qParams);

            return Ok(response.SuccessResponse("Ok", find));
        }
    }
}
