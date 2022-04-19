namespace HomeCare.Domain.Contracts
{
    [Serializable]
    public class ContractNotFoundException : Exception
    {
        public Guid ContractId { get; }

        public ContractNotFoundException(Guid guid)
        {
            ContractId = guid;
        }
    }
}
