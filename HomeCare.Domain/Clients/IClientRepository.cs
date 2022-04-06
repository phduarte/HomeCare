namespace ProjetoIntegradoTeste.Domain.Clients
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByUserName(string username);
        Client GetById(Guid clientId);
    }
}
