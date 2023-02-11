using System.Runtime.Serialization;

namespace HomeCare.Domain.Aggregates.Suppliers
{
    public class SupplierNotFoundException : DomainException, ISerializable
    {
        public Guid SupplierId { get; }

        public SupplierNotFoundException(Guid supplierId)
        {
            SupplierId = supplierId;
        }
    }
}
