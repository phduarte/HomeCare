namespace HomeCare.Domain.Payments
{
    public interface IPaymentService
    {
        PaymentReceipt Request(Payment payment);
        PaymentReceipt Refund(Payment payment);
        void Complete(Payment payment);
    }
}
