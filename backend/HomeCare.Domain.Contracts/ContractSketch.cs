namespace HomeCare.Domain.Contracts
{
    public class ContractSketch
    {
        public Guid SupplierId { get; set; }
        public Guid ClientId { get; set; }
        public string JobDescription { get; set; }
        public DateTime Date { get; set; }
    }
}
