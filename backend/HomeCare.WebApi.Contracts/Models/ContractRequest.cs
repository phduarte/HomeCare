using HomeCare.Domain.Aggregates.Contracts;
namespace HomeCare.WebApi.Contracts.Model;

public class ContractRequest
{
    public Guid ContractId { get; set; }

    public Contract ToModel()
    {
        return new Contract
        {
            Id = ContractId
        };
    }
}
