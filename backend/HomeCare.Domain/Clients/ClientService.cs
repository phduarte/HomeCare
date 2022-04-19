namespace HomeCare.Domain.Clients
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
            try
            {
                return _clientsRepository.GetById(clientId);
            }
            catch
            {
                return null;
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
                return null;
            }
        }
    }
}
