namespace HomeCare.Domain
{
    public interface IRepository<T> : IPort where T : IAggregateRoot
    {
    }
}
