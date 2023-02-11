using HomeCare.Domain.Aggregates.Contracts;

namespace HomeCare.Domain.Aggregates.Payments
{
    public class Payment : Entity, IAggregateRoot
    {
        public string Description { get; private set; }
        public IList<PaymentEvent> Events { get; private set; } = new List<PaymentEvent>();
        public Money Value { get; private set; }
        public PaymentReceipt? Receipt { get; private set; }
        public PaymentStatus Status { get; private set; }
        public PaymentEvent LastEvent => Events.LastOrDefault();
        public Contract Contract { get; private set; }

        public Payment(Guid guid, Contract contract, string description, PaymentStatus status, Money value)
        {
            Id = guid;
            Contract = contract;
            Description = description;
            Status = status;
            Value = value;
            AddEvent(Status = status);
        }

        public void Pay(PaymentReceipt receipt)
        {
            Receipt = receipt;
            AddEvent(Status = PaymentStatus.Requested);
        }

        public void Reverse(PaymentReceipt receipt)
        {
            Receipt = receipt;
            AddEvent(Status = PaymentStatus.Rejected);
        }

        public void Confirm()
        {
            AddEvent(Status = PaymentStatus.Confirmed);
        }

        public override string ToString()
        {
            return $"{Value} - {Status}";
        }

        private void AddEvent(PaymentStatus status)
        {
            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                Status = status,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "api"
            });
        }
    }
}
