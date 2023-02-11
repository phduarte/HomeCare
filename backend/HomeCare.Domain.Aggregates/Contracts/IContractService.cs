namespace HomeCare.Domain.Aggregates.Contracts
{
    public interface IContractService
    {
        Contract Emit(ContractSketch contract);
        Contract GetById(Guid guid);
        void Finish(Guid guid);
        void Done(Guid guid);
        void Cancel(Guid guid);
    }
}
