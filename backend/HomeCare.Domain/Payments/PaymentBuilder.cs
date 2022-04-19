using HomeCare.Domain.Contracts;

namespace HomeCare.Domain.Payments
{
    public class PaymentBuilder
    {
        private string _description = string.Empty;
        private PaymentStatus _paymentStatus = PaymentStatus.Created;
        private Contract _contract = null;
        private Money _value = 0;
        public Guid _id;

        private PaymentBuilder(Guid guid)
        {
            _id = guid;
        }

        public static PaymentBuilder Create(Guid? guid = default)
        {
            return new PaymentBuilder(guid ?? Guid.NewGuid());
        }

        public PaymentBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public PaymentBuilder WithStatus(PaymentStatus paymentStatus)
        {
            _paymentStatus = paymentStatus;
            return this;
        }

        public PaymentBuilder WithContract(Contract contract)
        {
            _contract = contract;
            return this;
        }

        public PaymentBuilder WithValue(Money value)
        {
            _value = value;
            return this;
        }

        public Payment Build()
        {
            var description = _description ?? $"{_contract.Client} pays {_contract.Supplier} for {_contract.JobDescription}";
            return new Payment(_id, _contract, description, _paymentStatus, _value);
        }
    }
}
