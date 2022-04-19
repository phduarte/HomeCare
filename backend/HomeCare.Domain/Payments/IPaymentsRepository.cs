namespace HomeCare.Domain.Payments
{
    public interface IPaymentsRepository : IRepository<Payment>
    {
        void Create(Payment payment);
        void Update(Payment payment);
        bool TryGetById(Guid id, out Payment payment);
        Payment GetById(Guid id);
    }
}
