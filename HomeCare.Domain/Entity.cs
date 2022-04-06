namespace ProjetoIntegradoTeste.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Entity<T> e && e.Id.Equals(Id);
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
