namespace HomeCare.Domain.Aggregates.Suppliers
{
    public interface ISuppliersRepository : IRepository<Supplier>
    {
        Supplier GetById(Guid guid);
        IQueryable<Supplier> Search(SearchCriteria criteria);
        Supplier GetByUserName(string username);
    }
}
