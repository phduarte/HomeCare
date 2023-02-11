using HomeCare.Domain.Aggregates.Payments;

namespace HomeCare.Adapters.RabbitMQ
{
    internal class PaymentsProcessedQueueService : QueueService, IPaymentsProcessedQueueService
    {
        public PaymentsProcessedQueueService(RabbitMqOptions options)
            : base(options.Uri, options.ProcessedQueueName)
        {
        }
    }
}
