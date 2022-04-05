namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    public interface ISuppliersRepository : IRepository<Supplier>
    {
        Supplier GetById(Guid guid);
        IQueryable<Supplier> Find(SearchCriteria criteria);
    }
}
