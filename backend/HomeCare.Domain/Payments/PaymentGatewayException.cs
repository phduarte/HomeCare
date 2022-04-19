using System.Runtime.Serialization;

namespace HomeCare.Domain.Payments
{
    [Serializable]
    public class PaymentGatewayException : Exception, ISerializable
    {
        public PaymentGatewayException()
        {
        }
    }
}
