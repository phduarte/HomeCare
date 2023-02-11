using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Payments
{
    [Serializable]
    public class PaymentNotFoundException : DomainException, ISerializable
    {
        public Guid PaymentUuid { get; }

        public PaymentNotFoundException(Guid guid)
        {
            PaymentUuid = guid;
        }
    }
}
