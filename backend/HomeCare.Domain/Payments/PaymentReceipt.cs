﻿namespace HomeCare.Domain.Payments
{
    public class PaymentReceipt
    {
        public string Protocol { get; set; }

        public override string ToString()
        {
            return Protocol;
        }
    }
}
