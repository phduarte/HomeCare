namespace HomeCare.Domain.Payments
{
    public interface IPaymentsProcessedQueueService
    {
        void Publish(Payment payment);
    }
}
