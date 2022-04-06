namespace ProjetoIntegradoTeste.Domain.Payments
{
    public class RequestForPayment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Value { get; set; }

        public static RequestForPayment CreateDebitFor(Payment payment)
        {
            return new RequestForPayment
            {
                Value = decimal.Negate(Math.Abs(payment.Value))
            };
        }

        public static RequestForPayment CreateCreditFor(Payment payment)
        {
            return new RequestForPayment
            {
                Value = Math.Abs(payment.Value)
            };
        }
    }
}
