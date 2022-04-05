using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoTeste.Domain.Contracts;
using ProjetoIntegradoTeste.Models;

namespace ProjetoIntegradoTeste.Controllers
{
    [ApiController]
    [Route("api/v1/public/hire")]
    public class ContractController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;
        private readonly IContractService _contractService;

        public ContractController(ILogger<ContractController> logger, IContractService contractService)
        {
            _logger = logger;
            _contractService = contractService;
        }

        [HttpPost("emmit")]
        [ProducesDefaultResponseType(typeof(ContractResponse))]
        public IActionResult Emmit(ContractRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contractService.Emmit(request.ToModel());

                    return Ok(string.Empty);
                }
                else
                {
                    return BadRequest(ModelState.LastOrDefault());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("finish")]
        [ProducesDefaultResponseType(typeof(ContractFinishedResponse))]
        public IActionResult Finish(ContractFinishRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contractService.Finish(request.ToModel());

                    return Ok(string.Empty);
                }
                else
                {
                    return BadRequest(ModelState.LastOrDefault());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}