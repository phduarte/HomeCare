using HomeCare.Domain.Aggregates.Clients;
using Moq;
using NUnit.Framework;
using System;

namespace HomeCare.Domain.Tests.Clients
{
    internal class ClientServiceTests
    {
        private Mock<IClientRepository> _clientsRepository;
        private IClientService _clientService;

        public ClientServiceTests()
        {
            _clientsRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientsRepository.Object);
        }

        [Test]
        public void GetById_WhenUserExists_ShouldBeSuccessful()
        {
            var client = new Client();

            _clientsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(client);

            var ret = _clientService.GetById(Guid.NewGuid());

            Assert.IsNotNull(ret);
        }

        [Test]
        public void GetById_WhenUserDoesNotExists_ShouldReturnNull()
        {
            var client = new Client();

            _clientsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Throws<Exception>();

            Assert.Throws<ClientNotFoundException>(() => _clientService.GetById(Guid.NewGuid()));
        }

        [Test]
        public void GetByUserName_WhenUserExists_ShouldBeSuccessful()
        {
            var client = new Client();

            _clientsRepository
                .Setup(s => s.GetByUserName(It.IsAny<string>()))
                .Returns(client);

            var ret = _clientService.GetByUsername(string.Empty);

            Assert.IsNotNull(ret);
        }

        [Test]
        public void GetByUserName_WhenUserDoesNotExists_ShouldReturnNull()
        {
            var client = new Client();

            _clientsRepository
                .Setup(s => s.GetByUserName(It.IsAny<string>()))
                .Throws<Exception>();

            var ret = _clientService.GetByUsername(string.Empty);

        }
    }
}
