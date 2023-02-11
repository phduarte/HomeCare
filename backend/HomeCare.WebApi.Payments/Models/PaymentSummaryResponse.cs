using HomeCare.Domain.Aggregates.Payments;

namespace HomeCare.WebApi.Payments.Models
{
    public class PaymentSummaryResponse
    {
        public Guid Id { get; set; }
        public string JobDescription { get; set; }
        public Money Value { get; set; }
        public List<PaymentEventResponse> Events { get; set; } = new List<PaymentEventResponse>();

        public static PaymentSummaryResponse Parse(IEnumerable<Payment> payment)
        {
            var first = payment.FirstOrDefault();
            if (first == null)
            {
                return new PaymentSummaryResponse();
            }

            return new PaymentSummaryResponse
            {
                Id = first.Id,
                JobDescription = first.Description,
                Value = first.Value,
                Events = payment.SelectMany(p => p.Events).Select(e => PaymentEventResponse.Parse(e)).ToList()
            };
        }
    }

    public class PaymentEventResponse
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }

        public static PaymentEventResponse Parse(PaymentEvent pevent)
        {
            return new PaymentEventResponse
            {
                CreatedAt = pevent.CreatedAt,
                CreatedBy = pevent.CreatedBy,
                Status = pevent.Status.ToString()
            };
        }
    }
}
