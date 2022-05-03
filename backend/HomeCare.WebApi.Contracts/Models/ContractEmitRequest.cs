using HomeCare.Domain.Contracts;
namespace HomeCare.WebApi.Contracts.Model;

public class ContractEmitRequest
{
    public Guid SupplierId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime ServiceDate { get; set; }
    public string JobDescription { get; set; }
    public decimal Value { get; set; }

    public ContractSketch ToModel()
    {
        return new ContractSketch
        {
            ClientId = ClientId,
            Date = ServiceDate,
            SupplierId = SupplierId,
            JobDescription = JobDescription,
        };
    }
}