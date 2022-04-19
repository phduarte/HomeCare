using HomeCare.Domain.Contracts;

namespace HomeCare.Models
{
    public class ContractEmitResponse
    {
        public Guid ContractId { get; set; }

        public static ContractEmitResponse Parse(Contract contract)
        {
            return new ContractEmitResponse
            {
                ContractId = contract.Id
            };
        }
    }
}
