using System;
using System.Linq;

namespace HomeCare.Domain.Suppliers
{
    public interface ISuppliersRepository : IRepository<Supplier>
    {
        Supplier GetById(Guid guid);
        IQueryable<Supplier> Search(SearchCriteria criteria);
    }
}
