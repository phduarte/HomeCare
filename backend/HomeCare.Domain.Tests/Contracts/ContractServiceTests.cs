using HomeCare.Domain.Aggregates.Clients;
using HomeCare.Domain.Aggregates.Payments;
using HomeCare.Domain.Aggregates.Shared;
using HomeCare.Domain.Aggregates.Suppliers;
using Moq;
using NUnit.Framework;
using System;

namespace HomeCare.Domain.Aggregates.Contracts
{
    internal class ContractServiceTests
    {
        private Mock<IContractsRepository> _contractsRepository;
        private Mock<ISupplierService> _supplierService;
        private Mock<IClientService> _clientService;
        private Mock<INotificationSender> _notificationFacade;
        private Mock<IPaymentRequestQueueService> _paymentRequestQueue;
        private IContractService _contractService;
        private Contract contract;
        private Client client;
        private Supplier supplier;

        [SetUp]
        public void Setup()
        {
            _contractsRepository = new Mock<IContractsRepository>();
            _supplierService = new Mock<ISupplierService>();
            _clientService = new Mock<IClientService>();
            _notificationFacade = new Mock<INotificationSender>();
            _paymentRequestQueue = new Mock<IPaymentRequestQueueService>();
            _contractService = new ContractService(_contractsRepository.Object, _supplierService.Object, _clientService.Object, _notificationFacade.Object, _paymentRequestQueue.Object);

            client = new();
            supplier = new();
            Money price = 100;
            string jobDescription = "instalação de janela";
            DateTime executionDate = DateTime.Today;

            contract = Contract.Create().With(client).With(supplier).With(price).With(jobDescription).With(executionDate);

            _contractsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(contract);
        }

        [Test]
        public void Emit_WhenContractIsSketched_ShouldBeEmitted()
        {
            var contractSketch = new ContractSketch();

            _clientService
                .Setup(s => s.GetById(contractSketch.ClientId))
                .Returns(new Client());

            _supplierService
                .Setup(s => s.GetById(contractSketch.SupplierId))
                .Returns(new Supplier());

            var ret = _contractService.Emit(contractSketch);

            _contractsRepository
                .Verify(s => s.Create(It.IsAny<Contract>()), Times.Once);

            _contractsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(contract);

            _paymentRequestQueue
                .Verify(s => s.Publish(It.IsAny<Payment>()), Times.Once);

            _notificationFacade
                .Verify(s => s.SendAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            Assert.AreEqual(ContractStatus.Emitted, ret.Status);
        }

        [Test]
        public void Done_WhenContractIsEmitted_ShouldBeDone()
        {
            contract.Emit();

            _contractService.Done(contract.Id);

            Assert.AreEqual(ContractStatus.Done, contract.Status);
        }

        [Test(Description = "Deve disparar uma excessão específica quando tentar concluir um contrato que não existe")]
        public void Done_WhenContractNotFound_ShouldThrowsContractNotFoundException()
        {
            contract.Emit();

            _contractsRepository
                .Setup(s => s.Update(contract))
                .Throws(new ContractNotFoundException(contract.Id));

            Assert.Throws<ContractNotFoundException>(() => _contractService.Done(contract.Id));

            _notificationFacade
                .Verify(s => s.SendAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Finish_WhenContractIsDone_ShouldBeFinished()
        {
            contract.Emit();
            contract.Done();

            _contractService.Finish(contract.Id);

            _contractsRepository
                    .Verify(s => s.Update(It.IsAny<Contract>()), Times.Once);

            Assert.AreEqual(ContractStatus.Finished, contract.Status);
        }

        [Test]
        public void Cancel_WhenContractIsEmitted_ShouldBeCanceled()
        {
            contract = Contract.Create().With(client).With(supplier).With(1).With("").With(DateTime.Today.AddDays(-61));
            contract.Emit();

            _contractsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(contract);

            _contractService.Cancel(contract.Id);

            _contractsRepository
                .Verify(s => s.Update(It.IsAny<Contract>()), Times.Once);

            Assert.AreEqual(ContractStatus.Canceled, contract.Status);
        }
    }
}
