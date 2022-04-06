namespace ProjetoIntegradoTeste.Domain.Payments
{
    public interface IPaymentService
    {
        void Pay(Payment payment);
        void Refund(Payment payment);
        void Complete(Payment payment);
    }
}
