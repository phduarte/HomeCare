using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoTeste.Domain.Suppliers;
using ProjetoIntegradoTeste.Models;

namespace ProjetoIntegradoTeste.Controllers
{
    [ApiController]
    [Route("api/v1/public/suppliers")]
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
        [ProducesDefaultResponseType(typeof(SearchResponse[]))]
        public IActionResult Search([FromQuery] SearchRequest request)
        {
            _logger.LogInformation("Find supplier begin");

            try
            {
                var criteria = SearchRequest.Parse(request);
                var suppliers = _supplierService.Search(criteria);
                var response = suppliers.Select(s => SearchResponse.Map(s));

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