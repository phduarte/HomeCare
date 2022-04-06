using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoTeste.Models;

namespace ProjetoIntegradoTeste.Controllers
{
    [ApiController]
    [Route("api/v1/public/payment")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("pay")]
        [ProducesDefaultResponseType(typeof(PaymentResponse))]
        public IActionResult Pay(PaymentRequest request)
        {
            return Ok(string.Empty);
        }

        [HttpPost("refund")]
        [ProducesDefaultResponseType(typeof(RefundResponse))]
        public IActionResult Refund(RefundRequest request)
        {
            return Ok(string.Empty);
        }
    }
}