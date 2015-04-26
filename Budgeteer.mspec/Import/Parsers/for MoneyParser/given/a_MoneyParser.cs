using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budgeteer.Domain.Currency;
using Budgeteer.Import.Parsers;
using Machine.Specifications;

namespace Budgeteer.mspec.Import.Parsers.for_MoneyParser.given
{
    public class a_MoneyParser
    {
        protected static MoneyParser Parser;
        protected static Money Result;
        protected static Money Expected;
        protected static string InputValue;

        private Establish context = () =>
        {
            Parser = new MoneyParser();
        };
    }
}
