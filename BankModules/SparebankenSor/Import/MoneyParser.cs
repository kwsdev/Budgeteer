using Common.Domain.Currency;

namespace BankModules.SparebankenSor.Import
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