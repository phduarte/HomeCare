using HomeCare.Domain.Payments;
using Moq;
using NUnit.Framework;
using System;

namespace HomeCare.Domain.Tests.Payments
{
    internal class PaymentServiceTests
    {
        private Mock<IPaymentGateway> _paymentGateway;
        private Mock<IPaymentsRepository> _paymentsRepository;
        private Mock<IPaymentsProcessedQueueService> _paymentsProcessedQueue;
        private Mock<IPaymentNotificationFacade> _notificationFacade;
        private readonly IPaymentService _paymentService;

        public PaymentServiceTests()
        {
            _paymentGateway = new Mock<IPaymentGateway>();
            _paymentsRepository = new Mock<IPaymentsRepository>();
            _paymentsProcessedQueue = new Mock<IPaymentsProcessedQueueService>();
            _notificationFacade = new Mock<IPaymentNotificationFacade>();
            _paymentService = new PaymentService(_paymentGateway.Object, _paymentsRepository.Object, _paymentsProcessedQueue.Object, _notificationFacade.Object);
        }

        [Test]
        public void Request_WhenPaymentIsValid_ShouldReturnPaymentReceipt()
        {
            var payment = PaymentBuilder.Create()
                .WithValue(100)
                .Build();

            _paymentGateway
                .Setup(s => s.Proccess(It.IsAny<RequestForPayment>()))
                .Returns(new PaymentReceipt
                {
                    Protocol = Guid.NewGuid().ToString(),
                });

            var receipt = _paymentService.Request(payment);

            Assert.NotNull(receipt);
            Assert.NotNull(receipt.Protocol);
            Assert.AreEqual(receipt.Protocol, receipt.ToString());
        }

        [Test]
        public void Request_WhenPaymentDoesNotExists_ShouldThrowsException()
        {
            var payment = PaymentBuilder.Create().Build();

            _paymentGateway
                .Setup(s => s.Proccess(It.IsAny<RequestForPayment>()))
                .Throws<Exception>();

            Assert.Throws<Exception>(() => _paymentService.Request(payment));
        }

        [Test]
        public void Refund_WhenPaymentExists_ShouldRefundThePayment()
        {
            var payment = PaymentBuilder.Create().Build();
            _paymentsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(payment);

            _paymentGateway
                .Setup(s => s.Proccess(It.IsAny<RequestForPayment>()))
                .Returns(new PaymentReceipt
                {
                    Protocol = Guid.NewGuid().ToString(),
                });

            var receipt = _paymentService.Refund(Guid.Empty);

            _paymentsProcessedQueue
                .Verify(s => s.Publish(It.IsAny<Payment>()), Times.Once);

            Assert.NotNull(receipt);
        }

        [Test]
        public void Refund_WhenPaymentDoesNotExists_ShouldThrowsException()
        {
            _paymentsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns<Payment>(null);

            Assert.Throws<PaymentNotFoundException>(() => _paymentService.Refund(Guid.Empty));

            _paymentsProcessedQueue
                .Verify(s => s.Publish(It.IsAny<Payment>()), Times.Once);
        }

        [Test]
        public void Refund_WhenPaymentDoesNotExists_ShouldNotSendToQueue()
        {
            _paymentsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns<Payment>(null);

            Assert.Throws<PaymentNotFoundException>(() => _paymentService.Refund(Guid.Empty));

            _paymentsProcessedQueue
                .Verify(s => s.Publish(It.IsAny<Payment>()), Times.Never);
        }

        [Test]
        public void Refund_WhenPaymentGatewayIsOffline_ShouldThrowsPaymentGatewayException()
        {
            _paymentsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(PaymentBuilder.Create().Build());

            _paymentGateway
                .Setup(s => s.Proccess(It.IsAny<RequestForPayment>()))
                .Throws<PaymentGatewayException>();

            Assert.Throws<PaymentGatewayException>(() => _paymentService.Refund(Guid.Empty));
        }

        [Test]
        public void Complete_Ok()
        {
            _paymentsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(PaymentBuilder.Create().Build());

            _paymentService.Complete(Guid.Empty);

            _notificationFacade
                .Verify(s => s.Notify(It.IsAny<Payment>()), Times.Once);
        }

        [Test]
        public void Complete_WhenPaymentNotFound_ShouldThrowsPaymentNotFoundException()
        {
            _paymentsRepository
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns<Payment>(null);

            Assert.Throws<PaymentNotFoundException>(() => _paymentService.Complete(Guid.Empty));

            _notificationFacade
                .Verify(s => s.Notify(It.IsAny<Payment>()), Times.Never);
        }
    }
}
