using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentsProcessedQueueService : IPaymentsProcessedQueueService
    {
        public void Publish(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
