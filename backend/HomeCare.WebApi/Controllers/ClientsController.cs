using HomeCare.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using HomeCare.Domain.Clients;

namespace HomeCare.Controllers
{
    [ApiController]
    [Route("api/v1/public/client")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientService _clientsService;

        public ClientsController(ILogger<ClientsController> logger,
            IClientService clientsService)
        {
            _logger = logger;
            _clientsService = clientsService;
        }

        [HttpPost("get")]
        [ProducesDefaultResponseType(typeof(ClientResponse))]
        public IActionResult Get(string username)
        {
            _logger.LogInformation("Get client begin.");

            if (_clientsService.GetByUsername(username) is Client client)
            {
                _logger.LogInformation("Get client end.");

                return Ok(ClientResponse.Parse(client));
            }
            else
            {
                _logger.LogInformation("Get client fail.");

                return NotFound();
            }
        }
    }
}