using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;
using HomeCare.SendGrid;
using Moq;
using NUnit.Framework;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading;

namespace HomeCare.Integrations.Tests
{
    public class SendGridNotificationFacadeTests
    {
        private SendGridNotificationFacade _sendGridNotificationFacade;
        private SendGridOptions _options;
        private Payment payment;
        private Contract contract;
        private Mock<SendGridClient> _sendGridClient;

        [SetUp]
        public void Setup()
        {
            _sendGridClient = new Mock<SendGridClient>();
            _sendGridNotificationFacade = new SendGridNotificationFacade(_sendGridClient.Object);
        }

        [Test]
        public void Notify_WhenPaymentIsValid_ShouldNotifySuccessful()
        {
            _sendGridNotificationFacade.Notify(payment);
            
            _sendGridClient
                .Verify(s => s.SendEmailAsync(It.IsAny<SendGridMessage>(), It.IsAny<CancellationToken>()),Times.Once);
        }

        [Test]
        public void Notify_WhenPaymentIsInvalid_ShouldFail()
        {
            _sendGridNotificationFacade.Notify(payment);
        }

        [Test]
        public void Notify_WhenContractIsValid_ShouldNotifySuccessful()
        {
            _sendGridNotificationFacade.Notify(contract);
        }

        [Test]
        public void Notify_WhenContractIsInvalid_ShouldFail()
        {
            _sendGridNotificationFacade.Notify(contract);
        }
    }
}