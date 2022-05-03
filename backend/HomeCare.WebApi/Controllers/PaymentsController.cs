using Microsoft.AspNetCore.Mvc;
using HomeCare.Domain.Payments;
using HomeCare.Models;
using HomeCare.WebApi.Models;

namespace HomeCare.Controllers
{
    [ApiController]
    [Route("v1/public/payment")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost("request")]
        [ProducesDefaultResponseType(typeof(PaymentResponse))]
        public IActionResult RequestPayment(PaymentRequest request)
        {
            try
            {
                var model = request.ToModel();
                var receipt = _paymentService.Request(model);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to request payment.");
                return BadRequest(ex);
            }
        }

        [HttpPost("refund")]
        [ProducesDefaultResponseType(typeof(PaymentRefundResponse))]
        public IActionResult Refund(PaymentRefundRequest request)
        {
            try
            {
                var receipt = _paymentService.Refund(request.Id);
                var response = PaymentRefundResponse.Parse(receipt);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to refund payment.");
                return BadRequest();
            }
        }

        [HttpPost("complete")]
        [ProducesDefaultResponseType(typeof(PaymentConfirmResponse))]
        public IActionResult Complete(Guid id)
        {
            try
            {
                _paymentService.Confirm(id);
                var response = PaymentConfirmResponse.Parse(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to complete payment.");
                return BadRequest();
            }
        }
    }
}