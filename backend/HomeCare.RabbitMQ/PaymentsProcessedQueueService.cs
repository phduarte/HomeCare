using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentsProcessedQueueService : IPaymentsProcessedQueueService
    {
        private RabbitMqOptions _options;

        public PaymentsProcessedQueueService(RabbitMqOptions options)
        {
            _options = options;
        }

        public void Publish(Payment payment)
        {
            var messageBroker = new MessageBroker(_options.Uri, _options.ProcessedQueueName);
            messageBroker.Publish(payment);
        }
    }
}
