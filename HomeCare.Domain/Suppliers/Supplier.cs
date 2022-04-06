namespace HomeCare.Domain.Suppliers
{
    public class Supplier : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public int Rate { get; set; } = 5;
        public Money Price { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }

        public bool Match(SearchCriteria criteria)
        {
            var ofereceServico = string.IsNullOrEmpty(criteria.Tag) || Tags.Any(x => x.Equals(criteria.Tag, StringComparison.OrdinalIgnoreCase));
            var distanciaDentroDoRaio = Location.Near(criteria.Location);

            return ofereceServico && distanciaDentroDoRaio;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
