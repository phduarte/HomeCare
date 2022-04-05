namespace ProjetoIntegradoTeste.Domain
{
    public interface ISpecification<T> where T : IAggregateRoot
    {
        bool IsSatisfied(T entity);
    }
}
