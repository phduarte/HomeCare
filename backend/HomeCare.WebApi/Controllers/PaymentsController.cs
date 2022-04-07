using Microsoft.AspNetCore.Mvc;
using HomeCare.Domain.Payments;

namespace HomeCare.Controllers
{
    [ApiController]
    [Route("api/v1/public/payment")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost("pay")]
        [ProducesDefaultResponseType(typeof(PaymentReceipt))]
        public IActionResult Pay(Payment request)
        {
            try
            {
                var receipt = _paymentService.Pay(request);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("refund")]
        [ProducesDefaultResponseType(typeof(PaymentReceipt))]
        public IActionResult Refund(Payment request)
        {
            try
            {
                var receipt = _paymentService.Refund(request);
                return Ok(receipt);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("complete")]
        [ProducesDefaultResponseType(typeof(PaymentReceipt))]
        public IActionResult Complete(Payment request)
        {
            try
            {
                _paymentService.Complete(request);
                return Ok(request);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}