namespace HomeCare.Domain.Contracts
{
    public interface IContractService
    {
        Contract Emmit(ContractSketch contract);
        void Finish(Contract contract);
        void Done(Contract contract);
    }
}
