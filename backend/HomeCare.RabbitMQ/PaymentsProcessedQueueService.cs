using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentsProcessedQueueService : QueueService, IPaymentsProcessedQueueService
    {
        public PaymentsProcessedQueueService(RabbitMqOptions options)
            : base(options.Uri, options.ProcessedQueueName)
        {
        }
    }
}
