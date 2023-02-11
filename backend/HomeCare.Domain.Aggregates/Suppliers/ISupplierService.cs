namespace HomeCare.Domain.Aggregates.Suppliers
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> Search(SearchCriteria criteria);
        Supplier GetById(Guid supplierId);
        Supplier GetByUserName(string username);
    }
}
