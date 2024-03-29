﻿namespace HomeCare.Domain.Payments
{
    public class PaymentEvent : Entity<Guid>
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
