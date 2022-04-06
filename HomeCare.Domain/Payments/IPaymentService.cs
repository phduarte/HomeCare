namespace HomeCare.Domain.Payments
{
    public interface IPaymentService
    {
        PaymentReceipt Pay(Payment payment);
        PaymentReceipt Refund(Payment payment);
        void Complete(Payment payment);
    }
}
