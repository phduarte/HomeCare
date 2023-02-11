namespace HomeCare.Domain.Aggregates.Payments
{
    public interface IPaymentRequestQueueService
    {
        void Publish(Payment payment);
    }
}
