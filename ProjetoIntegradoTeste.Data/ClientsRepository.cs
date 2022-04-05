﻿using ProjetoIntegradoTeste.Domain.Clients;

namespace ProjetoIntegradoTeste.Infrastructure.Data
{
    public class ClientsRepository : IClientsRepository
    {
        private static readonly IEnumerable<Client> _clients = new List<Client>()
        {
            new Client{ Id = Guid.Parse("{048EB20C-452C-4181-8870-BDC36B45DB9F}"), Name="Paulo", Username="paulo"},
            new Client{ Id = Guid.Parse("{5888B106-BC72-4845-B829-39A546F07955}"), Name="Angelo", Username="angelo"},
            new Client{ Id = Guid.Parse("{72998E62-324A-45BF-AC88-7CBDFF92EE2F}"), Name="Franclis",Username="galdino"}
        };

        public Client GetByUserName(string username)
        {
            return _clients.FirstOrDefault(x => x.Username.Equals(username));
        }
    }
}
