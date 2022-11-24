using apisistec.Helpers;
using apisistec.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/localization")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private ILocalizationService _service;
        DefaultResponses response = new();

        public LocalizationController(ILocalizationService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(response.SuccessResponse("Ok", _service.ProvincesWithCantons()));
        }
    }
}
