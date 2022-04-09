using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentRequestQueueService : IPaymentRequestQueueService
    {
        private readonly RabbitMqOptions _options;

        public PaymentRequestQueueService(RabbitMqOptions options)
        {
            _options = options;
        }

        public void Publish(Payment payment)
        {
            var messageBroker = new MessageBroker<Payment>(_options.Uri, _options.RequestedQueueName);
            messageBroker.Publish(payment);
        }
    }
}
