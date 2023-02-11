using HomeCare.Domain.Aggregates.Clients;
using HomeCare.Domain.Aggregates.Suppliers;

namespace HomeCare.Domain.Aggregates.Contracts
{
    public class Contract : Entity, IAggregateRoot
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

        public static Contract Create()
        {
            return new Contract
            {
                Id = Guid.NewGuid()
            };
        }

        public Contract With(Client client)
        {
            Client = client;
            return this;
        }

        public Contract With(Supplier supplier)
        {
            Supplier = supplier;
            return this;
        }

        public Contract With(Money money)
        {
            Price = money;
            return this;
        }

        public Contract With(string description)
        {
            JobDescription = description;
            return this;
        }

        public Contract With(DateTime dateTime)
        {
            ExecutionDate = dateTime;
            return this;
        }

        public Contract With(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
