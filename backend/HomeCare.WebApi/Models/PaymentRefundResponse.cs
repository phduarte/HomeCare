using HomeCare.Domain.Payments;

namespace HomeCare.WebApi.Models
{
    internal class PaymentRefundResponse
    {
        public string Protocol { get; private set; }

        public static PaymentRefundResponse Parse(PaymentReceipt receipt)
        {
            return new PaymentRefundResponse
            {
                Protocol = receipt.Protocol
            };
        }
    }
}
