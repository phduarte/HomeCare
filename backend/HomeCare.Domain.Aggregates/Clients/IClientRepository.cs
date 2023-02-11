using System;

namespace HomeCare.Domain.Aggregates.Clients
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByUserName(string username);
        Client GetById(Guid clientId);
        IEnumerable<Client> GetAll();
    }
}
