using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Payments
{
    [Serializable]
    public class PaymentGatewayException : DomainException, ISerializable
    {
        public PaymentGatewayException()
        {
        }
    }
}
