using HomeCare.Domain.Payments;

namespace HomeCare.Models
{
    public class PaymentRequest
    {
        public Guid Id { get; private set; }
        public decimal Value { get; private set; }

        public Payment ToModel()
        {
            return PaymentBuilder.Create()
                .WithValue(Value)
                .Build();
        }
    }
}
