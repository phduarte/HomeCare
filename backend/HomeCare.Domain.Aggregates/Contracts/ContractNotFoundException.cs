namespace HomeCare.Domain.Aggregates.Contracts
{
    [Serializable]
    public class ContractNotFoundException : DomainException
    {
        public Guid ContractId { get; }

        public ContractNotFoundException(Guid guid)
        {
            ContractId = guid;
        }
    }
}
