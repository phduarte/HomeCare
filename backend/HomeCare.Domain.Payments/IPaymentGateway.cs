namespace HomeCare.Domain.Payments
{
    public interface IPaymentGateway
    {
        PaymentReceipt Proccess(RequestForPayment requestForPayment);
    }
}
