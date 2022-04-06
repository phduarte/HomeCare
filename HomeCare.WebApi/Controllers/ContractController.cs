using HomeCare.Domain.Contracts;
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
                    var sketch = request.ToModel();
                    var contract = _contractService.Emmit(sketch);

                    return Ok(ContractResponse.Parse(contract));
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
                    var contract = request.ToModel();
                    _contractService.Finish(contract);

                    return Ok(ContractFinishedResponse.Parse(contract));
                }
                else
                {
                    return BadRequest(ModelState.LastOrDefault());
                }
            }
            catch (ContractNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}