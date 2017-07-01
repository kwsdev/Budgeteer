using Common.Domain.Currency;

namespace GjensidigeBank.Import
{
    public class MoneyParser
    {
        public Money ParseMoney(string value)
        {
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