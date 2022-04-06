using HomeCare.Domain.Contracts;
using ProjetoIntegradoTeste.Domain.Clients;
using ProjetoIntegradoTeste.Domain.Payments;
using ProjetoIntegradoTeste.Domain.Suppliers;

namespace ProjetoIntegradoTeste.Domain.Contracts
{
    internal class ContractService : IContractService
    {
        private readonly IPaymentRequestQueueService _paymentRequestQueue;
        private readonly IContractsRepository _contractsRepository;
        private readonly ISupplierService _supplierService;
        private readonly IClientService _clientService;
        private readonly IContractFinishedNotificationFacade _notificationFacade;

        public ContractService(IContractsRepository contractsRepository,
            ISupplierService supplierService,
            IClientService clientService,
            IContractFinishedNotificationFacade notificationFacade,
            IPaymentRequestQueueService paymentRequestQueue)
        {
            _contractsRepository = contractsRepository;
            _supplierService = supplierService;
            _clientService = clientService;
            _notificationFacade = notificationFacade;
            _paymentRequestQueue = paymentRequestQueue;
        }

        public Contract Emmit(ContractSketch contractSketch)
        {
            var client = _clientService.GetById(contractSketch.ClientId);
            var supplier = _supplierService.GetById(contractSketch.SupplierId);
            var contract = Contract.Create(client, supplier, supplier.Price, contractSketch.ServiceDate);

            contract.Emmit();

            var payment = new Payment
            {
                Description = string.Empty,
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Requested,
                Value = contract.Price
            };

            _contractsRepository.Create(contract);
            _notificationFacade.Notify(contract);
            _paymentRequestQueue.Publish(payment);

            return contract;
        }

        public void Finish(Contract contract)
        {
            contract.Finish();

            _contractsRepository.Update(contract);
            _notificationFacade.Notify(contract);
        }
    }
}
