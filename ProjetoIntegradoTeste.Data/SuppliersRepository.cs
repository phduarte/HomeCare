using ProjetoIntegradoTeste.Domain.Suppliers;

namespace ProjetoIntegradoTeste.Infrastructure.Data
{
    public class SuppliersRepository : ISuppliersRepository
    {
        static List<Supplier> _suppliers = new List<Supplier>
        {
            new Supplier
            {
                Id=Guid.Parse("{F0941629-5C8D-4A5E-87FC-237DFB513A64}"),
                Name = "Seu Zé"
            }
        };

        public IQueryable<Supplier> Find(SearchCriteria criteria)
        {
            return _suppliers
                .Where(x => x.Location.Near(criteria.Location))
                .AsQueryable();
        }

        public Supplier GetById(Guid guid)
        {
            return _suppliers.FirstOrDefault(x => x.Id == guid);
        }
    }
}
