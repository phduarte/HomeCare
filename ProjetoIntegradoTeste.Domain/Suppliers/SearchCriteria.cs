namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    public class SearchCriteria : ValueObject
    {
        public string ServiceName { get; set; }
        public Location Location { get; set; }

        public SearchType SearchType { get; set; }
    }
}
