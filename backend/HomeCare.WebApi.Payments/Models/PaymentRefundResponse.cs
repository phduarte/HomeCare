namespace HomeCare.WebApi.Payments.Models;

using HomeCare.Domain.Aggregates.Payments;

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