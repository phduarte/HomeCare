using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;

namespace HomeCare.SendGrid
{
    public class SendGridNotificationFacade : IPaymentNotificationFacade, IContractFinishedNotificationFacade
    {
        public void Notify(PaymentEvent payment)
        {
            Thread.Sleep(10000);
        }

        public void Notify(Contract contract)
        {
            Thread.Sleep(8000);
        }
    }
}
