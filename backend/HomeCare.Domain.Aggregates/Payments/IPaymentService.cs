namespace HomeCare.Domain.Aggregates.Payments
{
    public interface IPaymentService
    {
        PaymentReceipt Request(Payment id);
        PaymentReceipt Refund(Guid id);
        void Confirm(Guid id);
        Payment GetById(Guid id);
        IEnumerable<Payment> GetAllByContract(Guid contractId);
        IEnumerable<Payment> GetAll();
    }
}
