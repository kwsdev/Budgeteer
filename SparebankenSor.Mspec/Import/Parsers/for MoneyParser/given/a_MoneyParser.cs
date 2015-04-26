using Common.Domain.Currency;
using Machine.Specifications;
using SparebankenSor.Import.Parsers;

namespace SparebankenSor.Mspec.Import.Parsers.for_MoneyParser.given
{
    public class a_MoneyParser
    {
        protected static MoneyParser Parser;
        protected static Money Result;
        protected static Money Expected;
        protected static string InputValue;

        private Establish context = () => { Parser = new MoneyParser(); };
    }
}