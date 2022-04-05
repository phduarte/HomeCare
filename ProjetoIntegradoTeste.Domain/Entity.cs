namespace ProjetoIntegradoTeste.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Entity<T> entity && entity.Id.Equals(Id);
        }
    }
}
