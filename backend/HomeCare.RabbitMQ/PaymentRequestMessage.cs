using HomeCare.Domain;
using HomeCare.Domain.Contracts;
using HomeCare.Domain.Payments;

namespace HomeCare.RabbitMQ
{
    internal class PaymentRequestMessage
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public ContractMessage Contract { get; set; }

        public static PaymentRequestMessage Parse(Payment payment)
        {
            return new PaymentRequestMessage
            {
                Id = payment.Id,
                Value = payment.Value,
                Contract = ContractMessage.Parse(payment.Contract),
            };
        }
    }

    internal class ContractMessage
    {
        public Guid Id { get; set; }
        public UserMessage Client { get; set; }
        public UserMessage Supplier { get; set; }
        public string JobDescription { get; set; }
        public DateTime ExecutionDate { get; set; }

        public static ContractMessage Parse(Contract contract)
        {
            return new ContractMessage
            {
                Id = contract.Id,
                Client = UserMessage.Parse(contract.Client),
                ExecutionDate = contract.ExecutionDate,
                JobDescription = contract.JobDescription,
                Supplier = UserMessage.Parse(contract.Supplier)
            };
        }
    }

    internal class UserMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static UserMessage Parse(User user)
        {
            return new UserMessage
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }
    }
}
