namespace ProjetoIntegradoTeste.Domain.Clients
{
    internal class ClientService : IClientService
    {
        private readonly IClientRepository _clientsRepository;

        public ClientService(IClientRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public Client GetById(Guid clientId)
        {
            return _clientsRepository.GetById(clientId);
        }

        public Client GetByUsername(string username)
        {
            return _clientsRepository.GetByUserName(username);
        }
    }
}
