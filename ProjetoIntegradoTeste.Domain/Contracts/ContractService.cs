namespace ProjetoIntegradoTeste.Domain.Contracts
{
    internal class ContractService : IContractService
    {
        private readonly IContractsRepository _contractsRepository;
        private readonly IContractFinishedNotificationFacade _notificationFacade;

        public ContractService(IContractsRepository contractsRepository, IContractFinishedNotificationFacade notificationFacade)
        {
            _contractsRepository = contractsRepository;
            _notificationFacade = notificationFacade;
        }

        public void Emmit(Contract contract)
        {
            _contractsRepository.Create(contract);
            _notificationFacade.Notify(contract);
        }

        public void Finish(Contract contract)
        {
            _contractsRepository.Update(contract);
            _notificationFacade.Notify(contract);
        }
    }
}
