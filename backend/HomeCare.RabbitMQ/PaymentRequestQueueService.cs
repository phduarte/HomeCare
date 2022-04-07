using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentRequestQueueService : IPaymentRequestQueueService
    {
        public void Publish(Payment payment)
        {
            var messageBroker = new MessageBroker<Payment>("payments_requested");
            messageBroker.Publish(payment);
        }
    }
}
