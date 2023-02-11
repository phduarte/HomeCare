namespace HomeCare.Domain.Aggregates.Payments
{
    public interface IPaymentGateway
    {
        PaymentReceipt Proccess(RequestForPayment requestForPayment);
    }
}
