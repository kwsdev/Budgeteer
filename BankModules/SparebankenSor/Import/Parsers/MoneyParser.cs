using Common.Domain.Currency;

namespace SparebankenSor.Import.Parsers
{
    public class MoneyParser
    {
        public Money ParseMoney(string value)
        {
            value = value.Substring(3);
            value = value.Replace(((char) 65533).ToString(), "");
            decimal sum;
            var succeess = decimal.TryParse(value, out sum);

            if (succeess)
            {
                return new Money {Value = sum};
            }

            return null;
        }
    }
}