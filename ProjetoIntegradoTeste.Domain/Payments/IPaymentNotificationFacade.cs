namespace ProjetoIntegradoTeste.Domain.Payments
{
    public interface IPaymentNotificationFacade
    {
        void Notify(PaymentEvent payment);
    }
}
