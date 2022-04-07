using HomeCare.Domain.Contracts;

namespace HomeCare.Domain.Contracts
{
    public interface IContractService
    {
        Contract Emmit(ContractSketch contract);
        void Finish(Contract contract);
    }
}
