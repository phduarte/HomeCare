namespace ProjetoIntegradoTeste.Domain.Payments
{
    public interface IPaymentsProcessedQueueService
    {
        void Publish(Payment payment);
    }
}
