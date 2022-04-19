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
                    var contract = _contractService.Emit(request.ToModel());

                    return Ok(ContractEmitResponse.Parse(contract));
                }
                else
                {
                    return BadRequest(ModelState.LastOrDefault());
                }
            }
            catch (ContractIsNotPendingException)
            {
                return UnprocessableEntity();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(ContractFinishResponse))]
        public IActionResult Get(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contract = _contractService.GetById(id);

                    return Ok(contract);
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
            catch (ContractIsNotPendingException)
            {
                return UnprocessableEntity();
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

                    _contractService.Done(request.ContractId);

                    return Ok();
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
            catch (ContractIsNotPendingException)
            {
                return UnprocessableEntity();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("cancel")]
        [ProducesDefaultResponseType(typeof(ContractFinishResponse))]
        public IActionResult Cancel(ContractFinishRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _contractService.Cancel(request.ContractId);

                    return Ok();
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
            catch (ContractIsNotPendingException)
            {
                return UnprocessableEntity();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}