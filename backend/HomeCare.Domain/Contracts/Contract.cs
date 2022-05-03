using HomeCare.Domain.Clients;
using HomeCare.Domain.Suppliers;

namespace HomeCare.Domain.Contracts
{
    public class Contract : Entity<Guid>, IAggregateRoot
    {
        private CancelSpecification _cancelledSpecification = new();
        private PendingSpecification _pendingSpecification = new();
        private EmitSpecification _emitSpecification = new();
        private FinishSpecification _finishSpecification = new();

        public Client Client { get; private set; }
        public Supplier Supplier { get; private set; }
        public string JobDescription { get; private set; }
        public DateTime ExecutionDate { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public Money Price { get; private set; }
        public ContractStatus Status { get; private set; } = ContractStatus.Sketch;
        public bool IsPending => _pendingSpecification.IsSatisfied(this);
        public bool CanBeCancelled => _cancelledSpecification.IsSatisfied(this);
        public bool CanBeEmitted => _emitSpecification.IsSatisfied(this);
        public bool CanBeFinished => _finishSpecification.IsSatisfied(this);

        public void Emit()
        {
            if (CanBeEmitted)
            {
                UpdateStatus(ContractStatus.Emitted);
            }
        }

        public void Done()
        {
            if (!IsPending)
            {
                throw new ContractIsNotPendingException();
            }

            UpdateStatus(ContractStatus.Done);
        }

        public void Finish()
        {
            if (!CanBeFinished)
            {
                throw new ContractIsNotDoneException();
            }

            UpdateStatus(ContractStatus.Finished);
        }

        public void Cancel()
        {
            if (CanBeCancelled)
            {
                UpdateStatus(ContractStatus.Canceled);
            }
        }

        private void UpdateStatus(ContractStatus contractStatus)
        {
            Status = contractStatus;
            UpdateAt = DateTime.UtcNow;
        }

        public static Contract Create(Client client, Supplier supplier, Money price, string jobDescription, DateTime executionDate)
        {
            return new Contract
            {
                Id = Guid.NewGuid(),
                Client = client,
                Supplier = supplier,
                Price = price,
                JobDescription = jobDescription,
                ExecutionDate = executionDate
            };
        }
    }
}
