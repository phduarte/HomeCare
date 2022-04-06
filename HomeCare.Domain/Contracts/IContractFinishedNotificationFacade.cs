namespace HomeCare.Domain.Contracts
{
    public interface IContractFinishedNotificationFacade
    {
        void Notify(Contract contract);
    }
}
