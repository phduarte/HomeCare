namespace HomeCare.Domain.Aggregates.Payments
{
    public interface IPaymentsProcessedQueueService
    {
        void Publish(Payment payment);
    }
}
