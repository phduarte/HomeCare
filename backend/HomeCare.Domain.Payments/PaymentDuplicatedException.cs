using System.Runtime.Serialization;

namespace HomeCare.Domain.Payments
{
    public class PaymentDuplicatedException : Exception, ISerializable
    {
        public Guid PaymentUuid { get; }

        public PaymentDuplicatedException(Guid guid)
        {
            PaymentUuid = guid;
        }
    }
}
