namespace HomeCare.Domain.Payments
{
    public interface IPaymentRequestQueueService
    {
        void Publish(Payment payment);
    }
}
