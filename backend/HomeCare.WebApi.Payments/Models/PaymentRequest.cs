namespace HomeCare.WebApi.Payments.Models;

using HomeCare.Domain.Payments;

internal class PaymentRequest
{
    public Guid Id { get; set; }
    public decimal Value { get; set; }

    public Payment ToModel()
    {
        return PaymentBuilder.Create()
            .WithValue(Value)
            .Build();
    }
}
