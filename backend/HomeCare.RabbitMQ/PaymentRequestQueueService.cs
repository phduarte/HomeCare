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
            var messageBroker = new MessageBroker(_options.Uri, _options.RequestedQueueName);
            var message = PaymentRequestMessage.Parse(payment);

            messageBroker.Publish(message);
        }
    }

    internal class PaymentRequestMessage
    {
        public Guid Id { get; private set; }
        public decimal Value { get; private set; }

        public static PaymentRequestMessage Parse(Payment payment)
        {
            return new PaymentRequestMessage
            {
                Id = payment.Id,
                Value = payment.Value,
            };
        }
    }
}
