using HomeCare.Domain;

namespace HomeCare
{
    public class Money : ValueObject
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return $"{Currency} {Amount:N2}";
        }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static implicit operator Money(decimal money)
        {
            return Parse(money);
        }

        public static Money Parse(decimal price)
        {
            return new Money
            {
                Currency = "BRL",
                Amount = price,
            };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
