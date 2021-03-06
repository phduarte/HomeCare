using Microsoft.AspNetCore.Mvc;
using HomeCare.Domain.Suppliers;
using HomeCare.Models;

namespace HomeCare.Controllers
{
    [ApiController]
    [Route("v1/public/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly ILogger<SuppliersController> _logger;
        private readonly ISupplierService _supplierService;

        public SuppliersController(ILogger<SuppliersController> logger,
            ISupplierService supplierService)
        {
            _logger = logger;
            _supplierService = supplierService;
        }

        [HttpGet("search")]
        [ProducesDefaultResponseType(typeof(SupplierSearchResponse[]))]
        public IActionResult Search([FromQuery] SupplierSearchRequest request)
        {
            _logger.LogInformation("Find supplier begin");

            try
            {
                var criteria = SupplierSearchRequest.Parse(request);
                var suppliers = _supplierService.Search(criteria);
                var response = suppliers.Select(s => SupplierSearchResponse.Map(s));

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail while searching supplier");
                return BadRequest();
            }
            finally
            {
                _logger.LogInformation("Find supplier begin");
            }
        }
    }
}