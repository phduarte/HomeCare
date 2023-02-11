namespace HomeCare.Domain.Aggregates.Payments
{
    public interface IPaymentsRepository : IRepository<Payment>
    {
        void Add(Payment payment);
        void Update(Payment payment);
        bool TryGetById(Guid id, out Payment payment);
        Payment GetById(Guid id);
        IEnumerable<Payment> GetAllByContractId(Guid contractId);
        IEnumerable<Payment> GetAll();
    }
}
