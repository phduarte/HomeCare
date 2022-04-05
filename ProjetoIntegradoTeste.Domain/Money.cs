namespace ProjetoIntegradoTeste.Domain
{
    public class Money
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

        public static Money Parse(decimal price)
        {
            return new Money
            {
                Currency = "BRL",
                Value = price,
            };
        }
    }
}
