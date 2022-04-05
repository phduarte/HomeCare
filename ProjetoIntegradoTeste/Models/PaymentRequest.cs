namespace ProjetoIntegradoTeste.Models
{
    public class PaymentRequest
    {
        public Guid ProtocolNumber { get; set; }
    }

    public class PaymentResponse
    {
        public int PaymentId { get; set; }
        public Guid Receipt { get; set; }
    }

    public class RefundRequest
    {
        public Guid ProtocolNumber { get; set; }

    }

    public class RefundResponse
    {
        public int RefundId { get; set; }
        public Guid Receipt { get; set; }

    }
}
