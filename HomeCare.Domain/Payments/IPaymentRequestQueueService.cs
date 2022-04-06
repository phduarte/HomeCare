namespace ProjetoIntegradoTeste.Domain.Payments
{
    public interface IPaymentRequestQueueService
    {
        void Publish(Payment payment);
    }
}
