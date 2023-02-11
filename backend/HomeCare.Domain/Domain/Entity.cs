namespace HomeCare.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Entity e && e.Id.Equals(Id);
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 7761;
        }
    }
}
