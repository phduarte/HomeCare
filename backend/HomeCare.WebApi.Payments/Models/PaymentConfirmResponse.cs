namespace HomeCare.WebApi.Payments.Models; 

internal class PaymentConfirmResponse
{
    public Guid Id { get; private set; }

    public static PaymentConfirmResponse Parse(Guid id)
    {
        return new PaymentConfirmResponse
        {
            Id = id,
        };
    }
}
