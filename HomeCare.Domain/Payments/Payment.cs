namespace ProjetoIntegradoTeste.Domain.Payments
{
    public class Payment : Entity<Guid>, IAggregateRoot
    {
        public string Description { get; set; }
        public IList<PaymentEvent> Events { get; set; } = new List<PaymentEvent>();
        public Money Value { get; set; }
        public PaymentReceipt Receipt { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Created;
        public PaymentEvent LastEvent => Events.LastOrDefault();

        public Payment()
        {
            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                CreatedBy = "paulo",
                Payment = this,
                Status = PaymentStatus.Created
            });
        }

        public override string ToString()
        {
            return $"{Value} - {Status}";
        }

        public void Paid()
        {
            Status = PaymentStatus.Confirmed;

            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Confirmed,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "paulo",
                Payment = this
            });
        }

        public void Reversed()
        {
            Status = PaymentStatus.Rejected;

            Events.Add(new PaymentEvent
            {
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Rejected,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "paulo",
                Payment = this
            });
        }
    }
}
