namespace HomeCare.Domain.Clients
{
    public class Client : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
