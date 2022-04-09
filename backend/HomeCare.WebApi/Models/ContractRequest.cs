using HomeCare.Domain.Contracts;

namespace HomeCare.Models
{
    public class ContractRequest
    {
        public Guid SupplierId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string JobDescription { get; set; }

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
}
