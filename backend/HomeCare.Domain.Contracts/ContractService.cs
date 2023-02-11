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
        private readonly INotificationFacade _notificationFacade;

        public ContractService(IContractsRepository contractsRepository,
            ISupplierService supplierService,
            IClientService clientService,
            INotificationFacade notificationFacade,
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

            if (client is null)
            {
                throw new ClientNotFoundException(contractSketch.ClientId);
            }

            var supplier = _supplierService.GetById(contractSketch.SupplierId);

            if (supplier is null)
            {
                throw new SupplierNotFoundException(contractSketch.SupplierId);
            }

            var contract = Contract.Create()
                .With(client)
                .With(supplier)
                .With(supplier.Price)
                .With(contractSketch.JobDescription)
                .With(contractSketch.Date);

            contract.Emit();

            var payment = PaymentBuilder.Create()
                .WithValue(supplier.Price)
                .WithContract(contract)
                .WithStatus(PaymentStatus.Created)
                .Build();

            _contractsRepository.Create(contract);
            _paymentRequestQueue.Publish(payment);

            NotifyContractEmitted(contract);

            return contract;
        }

        public void Done(Guid guid)
        {
            var contract = _contractsRepository.GetById(guid);
            if (contract != null)
            {
                contract.Done();

                _contractsRepository.Update(contract);

                NotifyServiceIsDone(contract);
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

                NotifyContractFinished(contract);
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
                NotifyContractCancelled(contract);
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

        private void NotifyContractCancelled(Contract contract)
        {
            var text = $"O contrato {contract.Id} foi cancelado. O dinheiro será devolvido para o cliente.";

            _notificationFacade.SendEmailAsync(contract.Supplier, "Contrato cancelado", text);

            text = $"O contrato {contract.Id} foi cancelado. O dinheiro será devolvido para sua conta.";

            _notificationFacade.SendEmailAsync(contract.Client, "Contrato cancelado", text);
        }

        private void NotifyContractFinished(Contract contract)
        {
            var text = $"O cliente confirmou que o serviço contratado através do protocolo {contract.Id} está feito, por isso, o contrato será concluído. Em breve você receberá o dinheiro em sua conta.";

            _notificationFacade.SendEmailAsync(contract.Supplier, "Contrato concluído", text);

            text = $"Você confirmou que o serviço está concluído e por isso iremos finalizar o contrato {contract.Id}. Em breve o dinheiro será liberado para a conta do prestador.";

            _notificationFacade.SendEmailAsync(contract.Client, "Contrato concluído", text);
        }

        private void NotifyServiceIsDone(Contract contract)
        {
            var text = $"O prestador {contract.Supplier} informou que o serviço já foi concluído. Confirme a conclusão para que o prestador receba o dinheiro.";

            _notificationFacade.SendEmailAsync(contract.Client, "Serviço feito", text);

            text = $"Você informou que o serviço do contrato {contract.Id} está feito. Informamos o cliente para que ele confirme e após isso iremos liberar o dinheiro para sua conta.";

            _notificationFacade.SendEmailAsync(contract.Supplier, "Serviço feito", text);
        }

        private void NotifyContractEmitted(Contract contract)
        {
            var text = $"O cliente {contract.Client} acabou de te contratar! Fique atento que em breve ele entrará em contato com você para combinar o serviço.";

            _notificationFacade.SendEmailAsync(contract.Supplier, "Você foi contratado", text);
        }
    }
}
