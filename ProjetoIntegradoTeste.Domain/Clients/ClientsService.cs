namespace ProjetoIntegradoTeste.Domain.Clients
{
    internal class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public Client GetByUsername(string username)
        {
            return _clientsRepository.GetByUserName(username);
        }
    }
}
