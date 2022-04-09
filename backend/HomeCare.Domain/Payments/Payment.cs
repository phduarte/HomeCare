using HomeCare.Domain.Contracts;

namespace HomeCare.Domain.Payments
{
    public class Payment : Entity<Guid>, IAggregateRoot
    {
        public string Description { get; set; }
        public IList<PaymentEvent> Events { get; set; } = new List<PaymentEvent>();
        public Money Value { get; set; }
        public PaymentReceipt? Receipt { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Created;
        public PaymentEvent LastEvent => Events.LastOrDefault();
        public Contract Contract { get; set; }
        
        public Payment()
        {
            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                CreatedBy = "paulo",
                //Payment = this,
                Status = PaymentStatus.Created
            });
        }

        public override string ToString()
        {
            return $"{Value} - {Status}";
        }

        public void Paid(PaymentReceipt receipt)
        {
            Status = PaymentStatus.Confirmed;
            Receipt = receipt;

            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Confirmed,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "paulo",
                //Payment = this
            });
        }

        public void Reversed(PaymentReceipt receipt)
        {
            Status = PaymentStatus.Rejected;
            Receipt = receipt;

            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Rejected,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "paulo",
                //Payment = this
            });
        }
    }
}
