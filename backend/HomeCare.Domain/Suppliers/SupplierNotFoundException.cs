using System.Runtime.Serialization;

namespace HomeCare.Domain.Suppliers
{
    public class SupplierNotFoundException : Exception, ISerializable
    {
        public Guid SupplierId { get; }

        public SupplierNotFoundException(Guid supplierId)
        {
            SupplierId = supplierId;
        }
    }
}
