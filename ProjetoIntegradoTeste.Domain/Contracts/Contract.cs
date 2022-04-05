using ProjetoIntegradoTeste.Domain.Clients;

namespace ProjetoIntegradoTeste.Domain.Contracts
{
    public class Contract : Entity<Guid>, IAggregateRoot
    {
        private RefundSpecification _refundSpecification = new RefundSpecification();
        private PendingSpecification _pendingSpecification = new PendingSpecification();

        public Client Client { get; set; }
        public Suppliers.Supplier Supplier { get; set; }
        public DateTime ServiceDate { get; set; }
        public Money Price { get; set; }
        public ContractStatus Status { get; set; } = ContractStatus.Sketch;
        public bool IsPending => _pendingSpecification.IsSatisfied(this);
        public bool CanBeRefund => _refundSpecification.IsSatisfied(this);
    }
}
