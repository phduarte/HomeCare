using HomeCare.Domain.Contracts;

namespace HomeCare.WebApi.Contracts.Model
{
    public class ContractResponse
    {
        public Guid Id { get; private set; }
        public string Client { get; private set; }
        public string Supplier { get; private set; }
        public string JobDescription { get; private set; }
        public DateTime ServiceDate { get; private set; }
        public string Status { get; set; }

        public static ContractResponse Parse(Contract contract)
        {
            return new ContractResponse
            {
                Id = contract.Id,
                Client = contract.Client.Name,
                Supplier = contract.Supplier.Name,
                JobDescription = contract.JobDescription,
                ServiceDate = contract.ExecutionDate,
                Status = contract.Status.ToString()
            };
        }
    }
}
