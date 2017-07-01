using System;

namespace BankModules.SparebankenSor.Import
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