namespace HomeCare.Domain.Payments
{
    public interface IPaymentNotificationFacade
    {
        void Notify(Payment payment);
    }
}
