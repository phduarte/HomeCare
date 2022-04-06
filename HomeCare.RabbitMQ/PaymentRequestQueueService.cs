using ProjetoIntegradoTeste.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegradoTeste.RabbitMQ
{
    internal class PaymentRequestQueueService : IPaymentRequestQueueService
    {
        public void Publish(Payment payment)
        {
            //throw new NotImplementedException();
        }
    }
}
