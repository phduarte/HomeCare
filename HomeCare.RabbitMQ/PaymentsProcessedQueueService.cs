using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentsProcessedQueueService : IPaymentsProcessedQueueService
    {
        public void Publish(Payment payment)
        {
            var messageBroker = new MessageBroker<Payment>("payments_processed");
            messageBroker.Publish(payment);
        }
    }
}
