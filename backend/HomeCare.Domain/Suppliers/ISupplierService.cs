namespace HomeCare.Domain.Suppliers
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> Search(SearchCriteria criteria);
        Supplier GetById(Guid supplierId);
    }
}
