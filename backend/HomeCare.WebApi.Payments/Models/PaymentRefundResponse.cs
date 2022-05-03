namespace HomeCare.WebApi.Payments.Models;

using HomeCare.Domain.Payments;

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