using ProjetoIntegradoTeste.Domain.Contracts;

namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> Find(SearchCriteria location);
        void Hire(Contract contract);
    }
}
