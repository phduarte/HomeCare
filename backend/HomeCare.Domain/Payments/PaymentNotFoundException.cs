using System.Runtime.Serialization;

namespace HomeCare.Domain.Payments
{
    [Serializable]
    public class PaymentNotFoundException : Exception, ISerializable
    {
        public Guid PaymentUuid { get; }

        public PaymentNotFoundException(Guid guid)
        {
            PaymentUuid = guid;
        }
    }
}
