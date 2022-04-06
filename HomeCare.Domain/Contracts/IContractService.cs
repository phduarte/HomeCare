using HomeCare.Domain.Contracts;

namespace ProjetoIntegradoTeste.Domain.Contracts
{
    public interface IContractService
    {
        Contract Emmit(ContractSketch contract);
        void Finish(Contract contract);
    }
}
