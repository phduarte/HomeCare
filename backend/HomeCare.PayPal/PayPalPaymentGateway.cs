using HomeCare.Domain.Aggregates.Payments;

namespace HomeCare.Adapters.PayPal
{
    public class PayPalPaymentGateway : IPaymentGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestForPayment"></param>
        /// <exception cref="PaymentGatewayException">If the external service is not responsible</exception>
        /// <returns></returns>
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
