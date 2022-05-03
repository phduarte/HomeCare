using HomeCare.Domain.Payments;

namespace HomeCare.Data.InMemory
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly static List<Payment> _payments = new List<Payment>();

        public void Add(Payment payment)
        {
            _payments.Add(payment);
        }

        public bool TryGetById(Guid id, out Payment payment)
        {
            payment = GetById(id);

            return payment is not null;
        }

        public Payment GetById(Guid id)
        {
            return _payments.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Payment payment)
        {
            var ret = _payments.First(x => x.Equals(payment));

            _payments.Remove(ret);
            _payments.Add(payment);
        }

        public IEnumerable<Payment> GetAllByContractId(Guid contractId)
        {
            return _payments.Where(x => x.Contract.Id.Equals(contractId));
        }
    }
}
