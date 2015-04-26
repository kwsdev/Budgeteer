using System;

namespace Budgeteer.Import.Parsers
{
    public class DateParser
    {
        public DateTime ParseDate(string value)
        {
            DateTime outValue;
            var success = DateTime.TryParse(value, out outValue);

            return success ? outValue : DateTime.MinValue;
        }
    }
}