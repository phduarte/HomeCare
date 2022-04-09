namespace HomeCare.Domain
{
    public abstract class User : Entity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
