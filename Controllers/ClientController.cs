using apisistec.Dtos;
using apisistec.Dtos.Client;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;
        DefaultResponses response = new();

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Search([FromQuery] QueryParams qParams)
        {
            PaginationDto<ClientDto> find = _clientService.Find(qParams);

            return response.SuccessResponse("Ok", find);
        }
    }
}
