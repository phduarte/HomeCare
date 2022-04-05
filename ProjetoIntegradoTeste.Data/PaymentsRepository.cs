using ProjetoIntegradoTeste.Domain.Payments;

namespace ProjetoIntegradoTeste.Infrastructure.Data
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly static List<Payment> _payments = new List<Payment>();

        public void Create(Payment payment)
        {
            _payments.Add(payment);
        }

        public bool Exists(Payment payment)
        {
            return _payments.Contains(payment);
        }

        public void Update(Payment payment)
        {
            var ret = _payments.First(x => x.Equals(payment));

            _payments.Remove(ret);
            _payments.Add(payment);
        }
    }
}
