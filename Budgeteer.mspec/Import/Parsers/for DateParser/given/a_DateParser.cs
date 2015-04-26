using System;
using Budgeteer.Import.Parsers;
using Machine.Specifications;

namespace Budgeteer.mspec.Import.Parsers.for_DateParser.given
{
    public class a_DateParser
    {
        public static DateParser Parser;
        public static DateTime result;
        public static string inputValue;
        public static DateTime expected;

        private Establish context = () =>
        {
            Parser = new DateParser();
        };
    }
}
