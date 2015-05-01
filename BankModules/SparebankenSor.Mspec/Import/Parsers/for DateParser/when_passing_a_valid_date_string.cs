using System;
using Machine.Specifications;
using SparebankenSor.Mspec.Import.Parsers.for_DateParser.given;

namespace SparebankenSor.Mspec.Import.Parsers.for_DateParser
{
    [Subject("Trying to parse a string that contains a valid date")]
    public class when_passing_a_valid_date_string : a_DateParser
    {
        private Establish context = () =>
        {
            inputValue = "12.01.2015";
            expected = new DateTime(2015, 1, 12);
        };

        private Because of = () => result = Parser.ParseDate(inputValue);
        private It should_be_a_valid_date = () => result.ShouldEqual(expected);
    }
}