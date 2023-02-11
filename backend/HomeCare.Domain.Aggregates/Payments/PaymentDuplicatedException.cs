using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Payments
{
    public class PaymentDuplicatedException : DomainException, ISerializable
    {
        public Guid PaymentUuid { get; }

        public PaymentDuplicatedException(Guid guid)
        {
            PaymentUuid = guid;
        }
    }
}
