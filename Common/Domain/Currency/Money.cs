namespace Common.Domain.Currency
{
    public class Money
    {
        public decimal Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}