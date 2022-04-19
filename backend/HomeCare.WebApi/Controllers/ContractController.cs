using HomeCare.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using HomeCare.Models;

namespace HomeCare.Controllers
{
    [ApiController]
    [Route("v1/public/contract")]
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
        [ProducesDefaultResponseType(typeof(ContractEmitResponse))]
        public IActionResult Emmit(ContractEmitRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sketch = request.ToModel();
                    var contract = _contractService.Emit(sketch);

                    return Ok(ContractEmitResponse.Parse(contract));
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
        [ProducesDefaultResponseType(typeof(ContractFinishResponse))]
        public IActionResult Finish(ContractFinishRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contract = request.ToModel();
                    _contractService.Done(contract);

                    return Ok(ContractFinishResponse.Parse(contract));
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