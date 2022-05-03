namespace HomeCare.Domain.Clients
{
    public interface IClientService
    {
        Client GetByUsername(string username);
        Client GetById(Guid clientId);
        IEnumerable<Client> GetAll();
    }
}
