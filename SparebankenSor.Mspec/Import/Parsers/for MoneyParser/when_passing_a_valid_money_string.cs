using Common.Domain.Currency;
using Machine.Specifications;
using SparebankenSor.Mspec.Import.Parsers.for_MoneyParser.given;

namespace SparebankenSor.Mspec.Import.Parsers.for_MoneyParser
{
    internal class when_passing_a_valid_money_string : a_MoneyParser
    {
        private Establish context = () =>
        {
            InputValue = "kr 1 050,00";
            Expected = new Money {Value = 1050.00m};
        };

        private Because of = () => Result = Parser.ParseMoney(InputValue);
        private It should_be_a_valid_sum_of_money = () => Result.Value.ShouldEqual(Expected.Value);
    }
}