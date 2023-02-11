namespace HomeCare.Domain.Aggregates.Clients
{
    public interface IClientService
    {
        Client GetByUsername(string username);
        Client GetById(Guid clientId);
        IEnumerable<Client> GetAll();
    }
}
