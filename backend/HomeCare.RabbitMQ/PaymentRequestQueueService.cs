using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentRequestQueueService : QueueService, IPaymentRequestQueueService
    {
        public PaymentRequestQueueService(RabbitMqOptions options)
            : base(options.Uri, options.RequestedQueueName)
        {
        }
    }
}
