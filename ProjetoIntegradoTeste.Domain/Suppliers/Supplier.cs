namespace ProjetoIntegradoTeste.Domain.Suppliers
{
    public class Supplier : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public decimal Price { get; set; }
        public Location Location { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
