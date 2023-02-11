namespace HomeCare.Domain.Aggregates.Payments
{
    public class PaymentEvent : Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
