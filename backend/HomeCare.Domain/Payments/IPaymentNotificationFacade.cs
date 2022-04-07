namespace HomeCare.Domain.Payments
{
    public interface IPaymentNotificationFacade
    {
        void Notify(PaymentEvent payment);
    }
}
