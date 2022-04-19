namespace HomeCare.Domain.Contracts
{
    public interface IContractService
    {
        Contract Emit(ContractSketch contract);
        void Finish(Contract contract);
        void Done(Contract contract);
        void Cancel(Contract contract);
    }
}
