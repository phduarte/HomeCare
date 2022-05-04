//using HomeCare.Domain.Contracts;
//using HomeCare.Domain.Payments;
//using HomeCare.SendGrid;
//using Moq;
//using NUnit.Framework;
//using SendGrid;
//using SendGrid.Helpers.Mail;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace HomeCare.Integrations.Tests
//{
//    public class SendGridNotificationFacadeTests
//    {
//        private SendGridNotificationFacade _sendGridNotificationFacade;
//        private SendGridOptions _options;
//        private Payment payment;
//        private Contract contract;
//        private Mock<SendGridClient> _sendGridClient;

//        [SetUp]
//        public void Setup()
//        {
//            var sendGridClientOptions = new SendGridClientOptions
//            {
//                ApiKey = "API_KEY_HERE",
//                Host = "hostname",
//                UrlPath = "http://localhost",
//            };
//            _sendGridClient = new Mock<SendGridClient>(sendGridClientOptions);
//            _sendGridNotificationFacade = new SendGridNotificationFacade(_sendGridClient.Object);
//            var client = new Domain.Clients.Client
//            {
//                Email = "alias@dominio.com.br",
//                Id = Guid.NewGuid(),
//                Name = "John Doe",
//                Username = "alias"
//            };
//            var supplier = new Domain.Suppliers.Supplier
//            {
//                Email = "alias@dominio.com.br",
//                Id = Guid.NewGuid(),
//                Name = "John Doe",
//                Username = "alias",
//                Location = new Domain.Suppliers.Location
//                {
//                    Latitude = 0,
//                    Longitude = 0,
//                    Range = 1
//                },
//                Price = 100,
//                Rate = 5,
//                Tags = new string[] { "servico1", "servico2" }
//            };
//            contract = Contract.Create(client, supplier, 1, "contract description", DateTime.Today);
//            payment = new Payment(Guid.Parse("{369D155B-5F93-4223-96C5-2A45D9D07CCD}"), contract, "description", PaymentStatus.Confirmed, 1);
//        }

//        [Test]
//        public void Notify_WhenPaymentIsValid_ShouldNotifySuccessful()
//        {
//            _sendGridNotificationFacade.Notify(payment);

//            //_sendGridClient
//            //    .Verify(s => s.SendEmailAsync(It.IsAny<SendGridMessage>(), It.IsAny<CancellationToken>()), Times.Once);
//        }

//        [Test]
//        public void Notify_WhenPaymentIsInvalid_ShouldFail()
//        {
//            _sendGridNotificationFacade.Notify(payment);
//        }

//        [Test]
//        public void Notify_WhenContractIsValid_ShouldNotifySuccessful()
//        {
//            _sendGridNotificationFacade.NotifyContractCancelled(contract);
//        }

//        [Test]
//        public void Notify_WhenContractIsInvalid_ShouldFail()
//        {
//            _sendGridNotificationFacade.NotifyContractCancelled(contract);
//        }
//    }
//}