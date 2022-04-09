using HomeCare.Domain.Contracts;
using HomeCare.Domain.Clients;
using HomeCare.Domain.Payments;
using HomeCare.Domain.Suppliers;

namespace HomeCare.Domain.Contracts
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
            var contract = Contract.Create(client, supplier, supplier.Price, contractSketch.JobDescription, contractSketch.Date);

            contract.Emmit();

            var payment = new Payment
            {
                Description = $"{client} pays {supplier} for {contract.JobDescription}",
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Requested,
                Value = contract.Price,
                Contract = contract
            };

            _contractsRepository.Create(contract);
            _paymentRequestQueue.Publish(payment);
            _notificationFacade.Notify(contract);

            return contract;
        }

        public void Done(Contract contract)
        {
            contract.Done();

            _contractsRepository.Update(contract);
            _notificationFacade.Notify(contract);
        }

        public void Finish(Contract contract)
        {
            contract.Finish();
            _contractsRepository.Update(contract);
        }
    }
}
