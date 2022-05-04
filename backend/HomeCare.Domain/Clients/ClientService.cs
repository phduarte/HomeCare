namespace HomeCare.Domain.Clients
{
    internal class ClientService : IClientService
    {
        private readonly IClientRepository _clientsRepository;

        public ClientService(IClientRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientsRepository.GetAll();
        }

        public Client GetById(Guid clientId)
        {
            try
            {
                return _clientsRepository.GetById(clientId);
            }
            catch
            {
                throw new ClientNotFoundException(clientId);
            }
        }

        public Client GetByUsername(string username)
        {
            try
            {
                return _clientsRepository.GetByUserName(username);
            }
            catch
            {
            }

            return null;
        }
    }
}
