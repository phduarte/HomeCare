using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoTeste.Domain.Clients;
using ProjetoIntegradoTeste.Models;

namespace ProjetoIntegradoTeste.Controllers
{
    [ApiController]
    [Route("api/v1/public/client")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientsService _clientsService;

        public ClientsController(ILogger<ClientsController> logger,
            IClientsService clientsService)
        {
            _logger = logger;
            _clientsService = clientsService;
        }

        [HttpPost("get")]
        [ProducesDefaultResponseType(typeof(ContractResponse))]
        public IActionResult Get(string username)
        {
            _logger.LogInformation("Get client begin.");

            if (_clientsService.GetByUsername(username) is Client client)
            {
                _logger.LogInformation("Get client end.");

                return Ok(client);
            }
            else
            {
                _logger.LogInformation("Get client fail.");

                return NotFound();
            }
        }
    }
}