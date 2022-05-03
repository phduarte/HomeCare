namespace HomeCare.Domain.Payments
{
    internal class PaymentService : IPaymentService
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IPaymentsProcessedQueueService _paymentsProcessedQueue;
        private readonly INotificationFacade _notificationFacade;

        public PaymentService(IPaymentGateway gateway,
            IPaymentsRepository paymentsRepository,
            IPaymentsProcessedQueueService paymentsProcessedQueue,
            INotificationFacade notificationFacade)
        {
            _paymentGateway = gateway;
            _paymentsRepository = paymentsRepository;
            _paymentsProcessedQueue = paymentsProcessedQueue;
            _notificationFacade = notificationFacade;
        }

        public PaymentReceipt Request(Payment payment)
        {
            var exists = _paymentsRepository.GetById(payment.Id);

            if (exists != null)
            {
                throw new PaymentDuplicatedException(payment.Id);
            }

            var request = RequestForPayment.CreateDebitFor(payment);
            var receipt = _paymentGateway.Proccess(request);

            payment.Pay(receipt);

            _paymentsRepository.Add(payment);
            _paymentsProcessedQueue.Publish(payment);

            return receipt;
        }

        public PaymentReceipt Refund(Guid id)
        {
            var payment = _paymentsRepository.GetById(id) ?? throw new PaymentNotFoundException(id);
            var request = RequestForPayment.CreateCreditFor(payment);
            var receipt = _paymentGateway.Proccess(request);

            payment.Reverse(receipt);

            _paymentsRepository.Update(payment);
            _paymentsProcessedQueue.Publish(payment);

            NotifyPaymentRefund(payment);

            return receipt;
        }

        /// <summary>
        /// Esse método é importante para manter a consistência de apenas o serviço de pagamentos conectar ao banco PAYMENTS
        /// Ele não é feito dentro do método Pay ou Refund pq esses métodos já possuem uma chamada crítica (gateway de pagamentos) e caso ele falhe, podemos ter inconsistência de dados no banco ou pagamentos em duplicidade
        /// por isso pagamentos só é salvo no banco depois que a integração externa é concluída, porém, o worker rebate nesse mesmo microserviço para que ele complete o pagamento e notifique o cliente.
        /// </summary>
        /// <param name="payment"></param>
        public void Confirm(Guid id)
        {
            var payment = _paymentsRepository.GetById(id) ?? throw new PaymentNotFoundException(id);

            payment.Confirm();
            _paymentsRepository.Update(payment);
            NotifyPaymentConfirmed(payment);
        }

        public Payment GetById(Guid id)
        {
            return _paymentsRepository.GetById(id);
        }

        private void NotifyPaymentRefund(Payment payment)
        {
            var text = $"O pagamento no valor de {payment.Value} referente ao contrato {payment.Contract} foi devolvido.";

            _notificationFacade.SendEmailAsync(payment.Contract.Client, "Pagamento foi estornado", text);
        }

        private void NotifyPaymentConfirmed(Payment payment)
        {
            var text = $"Seu pagamento foi confirmado. Entre em contato com o prestador {payment.Contract.Supplier.Name} através do e-mail {payment.Contract.Supplier.Email} para combinar o serviço!.";

            _notificationFacade.SendEmailAsync(payment.Contract.Supplier, "Pagamento confirmado", text);
        }

        public IEnumerable<Payment> GetAllByContract(Guid contractId)
        {
            return _paymentsRepository.GetAllByContractId(contractId);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _paymentsRepository.GetAll();
        }
    }
}
