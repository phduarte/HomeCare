using ProjetoIntegradoTeste.Domain.Clients;
using ProjetoIntegradoTeste.Domain.Suppliers;

namespace ProjetoIntegradoTeste.Domain.Contracts
{
    public class Contract : Entity<Guid>, IAggregateRoot
    {
        private RefundSpecification _refundSpecification = new RefundSpecification();
        private PendingSpecification _pendingSpecification = new PendingSpecification();

        public Client Client { get; private set; }
        public Supplier Supplier { get; private set; }
        public DateTime ServiceDate { get; private set; }
        public Money Price { get; private set; }
        public ContractStatus Status { get; private set; } = ContractStatus.Sketch;
        public bool IsPending => _pendingSpecification.IsSatisfied(this);
        public bool CanBeRefund => _refundSpecification.IsSatisfied(this);

        public void Emmit()
        {
            Status = ContractStatus.Emmited;
        }

        public void Finish()
        {
            Status = ContractStatus.Finished;
        }

        public static Contract Create(Client client, Supplier supplier, Money price, DateTime serviceDate)
        {
            return new Contract
            {
                Id = Guid.NewGuid(),
                Client = client,
                Supplier = supplier,
                Price = price,
                ServiceDate = serviceDate
            };
        }
    }
}
