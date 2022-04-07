using HomeCare.Domain.Payments;

namespace HomeCare.PayPal
{
    public class PayPalPaymentGateway : IPaymentGateway
    {
        public PaymentReceipt Proccess(RequestForPayment requestForPayment)
        {
            Thread.Sleep(3000);

            return new PaymentReceipt
            {
                Protocol = Guid.NewGuid().ToString(),
            };
        }
    }
}
