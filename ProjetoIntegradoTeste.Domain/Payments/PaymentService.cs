namespace ProjetoIntegradoTeste.Domain.Payments
{
    internal class PaymentService : IPaymentService
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IPaymentsProcessedQueueService _paymentsProcessedQueue;
        private readonly IPaymentNotificationFacade _notificationFacade;

        public PaymentService(IPaymentGateway gateway,
            IPaymentsRepository paymentsRepository,
            IPaymentsProcessedQueueService paymentsProcessedQueue,
            IPaymentNotificationFacade notificationFacade)
        {
            _paymentGateway = gateway;
            _paymentsRepository = paymentsRepository;
            _paymentsProcessedQueue = paymentsProcessedQueue;
            _notificationFacade = notificationFacade;
        }

        public void Pay(Payment payment)
        {
            var request = RequestForPayment.CreateDebitFor(payment);

            _paymentGateway.Proccess(request);

            payment.Paid();

            _paymentsProcessedQueue.Publish(payment);
        }

        public void Refund(Payment payment)
        {
            var request = RequestForPayment.CreateCreditFor(payment);

            _paymentGateway.Proccess(request);

            payment.Reversed();

            _paymentsProcessedQueue.Publish(payment);
        }

        /// <summary>
        /// Esse método é importante para manter a consistência de apenas o serviço de pagamentos conectar ao banco PAYMENTS
        /// Ele não é feito dentro do método Pay ou Refund pq esses métodos já possuem uma chamada crítica (gateway de pagamentos) e caso ele falhe, podemos ter inconsistência de dados no banco ou pagamentos em duplicidade
        /// por isso pagamentos só é salvo no banco depois que a integração externa é concluída, porém, o worker rebate nesse mesmo microserviço para que ele complete o pagamento e notifique o cliente.
        /// </summary>
        /// <param name="payment"></param>
        public void Complete(Payment payment)
        {
            if (!_paymentsRepository.Exists(payment))
            {
                _paymentsRepository.Create(payment);
            }

            _notificationFacade.Notify(payment.LastEvent);
        }
    }
}
