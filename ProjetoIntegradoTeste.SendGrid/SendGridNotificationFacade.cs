using ProjetoIntegradoTeste.Domain.Contracts;
using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.SendGrid
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
