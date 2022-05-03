using System;

namespace HomeCare.Worker.Models;

public class PaymentMessage
{
    public Guid Id { get; set; }
    public decimal Value { get; set; }
    public ContractMessage Contract { get; set; }
}
