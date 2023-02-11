using HomeCare.Domain.Aggregates.Payments;

namespace HomeCare.Adapters.RabbitMQ
{
    internal class PaymentRequestQueueService : QueueService, IPaymentRequestQueueService
    {
        public PaymentRequestQueueService(RabbitMqOptions options)
            : base(options.Uri, options.RequestedQueueName)
        {
        }
    }
}
