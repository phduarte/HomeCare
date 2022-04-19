namespace HomeCare.Domain.Payments
{
    public interface IPaymentService
    {
        PaymentReceipt Request(Payment id);
        PaymentReceipt Refund(Guid id);
        void Complete(Guid id);
    }
}
