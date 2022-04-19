using FluentAssertions;
using HomeCare.Domain.Clients;
using HomeCare.Domain.Payments;
using HomeCare.Domain.Suppliers;
using Moq;
using NUnit.Framework;
using System;

namespace HomeCare.Domain.Contracts
{
    internal class ContractServiceTests
    {
        private Mock<IContractsRepository> _contractsRepository;
        private Mock<ISupplierService> _supplierService;
        private Mock<IClientService> _clientService;
        private Mock<IContractFinishedNotificationFacade> _notificationFacade;
        private Mock<IPaymentRequestQueueService> _paymentRequestQueue;
        private IContractService _contractService;

        public ContractServiceTests()
        {
            _contractsRepository = new Mock<IContractsRepository>();
            _supplierService = new Mock<ISupplierService>();
            _clientService = new Mock<IClientService>();
            _notificationFacade = new Mock<IContractFinishedNotificationFacade>();
            _paymentRequestQueue = new Mock<IPaymentRequestQueueService>();
            _contractService = new ContractService(_contractsRepository.Object, _supplierService.Object, _clientService.Object, _notificationFacade.Object, _paymentRequestQueue.Object);
        }

        [Test]
        public void Emit()
        {
            var contractSketch = new ContractSketch
            {

            };

            _clientService
                .Setup(s => s.GetById(contractSketch.ClientId))
                .Returns(new Client());

            _supplierService
                .Setup(s => s.GetById(contractSketch.SupplierId))
                .Returns(new Supplier());

            var ret = _contractService.Emit(contractSketch);

            _contractsRepository
                .Verify(s => s.Create(It.IsAny<Contract>()), Times.Once);

            _paymentRequestQueue
                .Verify(s => s.Publish(It.IsAny<Payment>()), Times.Once);

            _notificationFacade
                .Verify(s => s.Notify(It.IsAny<Contract>()));

            Assert.AreEqual(ContractStatus.Emitted, ret.Status);
        }

        [Test]
        public void Done()
        {
            Client client = new();
            Supplier supplier = new();
            Money price = 100;
            string jobDescription = "instalação de janela";
            DateTime executionDate = DateTime.Today;

            var contract = Contract.Create(client, supplier, price, jobDescription, executionDate);

            _contractService.Done(contract.Id);

            Assert.AreEqual(ContractStatus.Done, contract.Status);
        }

        [Test(Description = "Deve disparar uma excessão específica quando tentar concluir um contrato que não existe")]
        public void Done_ShouldFail()
        {
            Client client = new();
            Supplier supplier = new();
            Money price = 100;
            string jobDescription = "instalação de janela";
            DateTime executionDate = DateTime.Today;
            var contract = Contract.Create(client, supplier, price, jobDescription, executionDate);

            _contractsRepository
                .Setup(s => s.Update(contract))
                .Throws(new ContractNotFoundException(contract.Id));

            Assert.Throws<ContractNotFoundException>(() => _contractService.Done(contract.Id));

            _notificationFacade
                .Verify(s => s.Notify(contract), Times.Never);
        }

        [Test]
        public void Finish()
        {
            Client client = new();
            Supplier supplier = new();
            Money price = 100;
            string jobDescription = "instalação de janela";
            DateTime executionDate = DateTime.Today;

            var contract = Contract.Create(client, supplier, price, jobDescription, executionDate);

            _contractService.Finish(contract.Id);

            Assert.AreEqual(ContractStatus.Finished, contract.Status);
        }

        [Test]
        public void Cancel()
        {
            Client client = new();
            Supplier supplier = new();
            Money price = 100;
            string jobDescription = "instalação de janela";
            DateTime executionDate = DateTime.Today;

            var contract = Contract.Create(client, supplier, price, jobDescription, executionDate);

            _contractService.Cancel(contract.Id);

            Assert.AreEqual(ContractStatus.Finished, contract.Status);
        }
    }
}
