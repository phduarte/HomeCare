namespace ProjetoIntegradoTeste.Domain.Payments
{
    public interface IPaymentsRepository : IRepository<Payment>
    {
        void Create(Payment payment);
        void Update(Payment payment);
        bool Exists(Payment payment);
    }
}
