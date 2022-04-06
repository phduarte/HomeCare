namespace HomeCare.Domain.Suppliers
{
    internal class SupplierService : ISupplierService
    {

        private readonly ISuppliersRepository _suppliersRepository;

        public SupplierService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public IEnumerable<Supplier> Search(SearchCriteria criteria)
        {
            var suppliers = _suppliersRepository.Search(criteria);

            if (criteria.SearchType == SearchType.Price)
            {
                suppliers = suppliers.OrderBy(x => x.Price.Value);
            }
            else if (criteria.SearchType == SearchType.Quality)
            {
                suppliers = suppliers.OrderByDescending(x => x.Rate).ThenBy(x => x.Price.Value);
            }

            return suppliers;
        }

        public Supplier GetById(Guid supplierId)
        {
            return _suppliersRepository.GetById(supplierId);
        }
    }
}
