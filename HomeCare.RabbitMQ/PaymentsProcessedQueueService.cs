using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.RabbitMQ
{
    internal class PaymentsProcessedQueueService : IPaymentsProcessedQueueService
    {
        public void Publish(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
