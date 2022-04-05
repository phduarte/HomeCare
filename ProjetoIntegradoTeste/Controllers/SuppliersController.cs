using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoTeste.Models;

namespace ProjetoIntegradoTeste.Controllers
{
    [ApiController]
    [Route("api/v1/public/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly ILogger<SuppliersController> _logger;

        public SuppliersController(ILogger<SuppliersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("find")]
        [ProducesDefaultResponseType(typeof(SearchResponse[]))]
        public IActionResult Search([FromQuery]SearchRequest request)
        {
            return Ok(string.Empty);
        }

        [HttpPost("hire")]
        [ProducesDefaultResponseType(typeof(ContractResponse[]))]
        public IActionResult Hire([FromQuery] ContractRequest request)
        {
            return Ok(string.Empty);
        }
    }
}