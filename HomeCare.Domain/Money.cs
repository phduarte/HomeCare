namespace HomeCare.Domain
{
    public class Money : ValueObject
    {
        public decimal Value { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return $"{Currency} {Value:N2}";
        }

        public static implicit operator decimal(Money money)
        {
            return money.Value;
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
                Value = price,
            };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}
