namespace ProjetoIntegradoTeste.Domain.Clients
{
    public interface IClientsRepository : IRepository<Client>
    {
        Client GetByUserName(string username);
    }
}
