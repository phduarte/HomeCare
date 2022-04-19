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

        public Contract Emit(ContractSketch contractSketch)
        {
            var client = _clientService.GetById(contractSketch.ClientId);
            var supplier = _supplierService.GetById(contractSketch.SupplierId);
            var contract = Contract.Create(client, supplier, supplier.Price, contractSketch.JobDescription, contractSketch.Date);

            contract.Emit();

            var payment = PaymentBuilder.Create()
                .WithValue(supplier.Price)
                .WithContract(contract)
                .WithStatus(PaymentStatus.Created)
                .Build();

            _contractsRepository.Create(contract);
            _paymentRequestQueue.Publish(payment);
            _notificationFacade.Notify(contract);

            return contract;
        }

        public void Done(Guid guid)
        {
            var contract = _contractsRepository.GetById(guid);
            if (contract != null)
            {
                contract.Done();

                _contractsRepository.Update(contract);
                _notificationFacade.Notify(contract);
            }
            else
            {
                throw new ContractNotFoundException(guid);
            }
        }

        public void Finish(Guid guid)
        {
            var contract = _contractsRepository.GetById(guid);

            if (contract != null)
            {
                contract.Finish();
                _contractsRepository.Update(contract);
            }
            else
            {
                throw new ContractNotFoundException(guid);
            }
        }

        public void Cancel(Guid guid)
        {
            var contract = _contractsRepository.GetById(guid);

            if (contract != null)
            {
                contract.Cancel();

                _contractsRepository.Update(contract);
                _notificationFacade.Notify(contract);
            }
            else
            {
                throw new ContractNotFoundException(guid);
            }
        }

        public Contract GetById(Guid guid)
        {
            var contract = _contractsRepository.GetById(guid);

            if (contract != null)
            {
                return contract;
            }

            throw new ContractNotFoundException(guid);
        }
    }
}
