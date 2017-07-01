using System;
using BankModules.SparebankenSor.Import;
using Machine.Specifications;

namespace SparebankenSor.Mspec.Import.Parsers.for_DateParser.given
{
    public class a_DateParser
    {
        public static DateParser Parser;
        public static DateTime result;
        public static string inputValue;
        public static DateTime expected;
        private Establish context = () => { Parser = new DateParser(); };
    }
}