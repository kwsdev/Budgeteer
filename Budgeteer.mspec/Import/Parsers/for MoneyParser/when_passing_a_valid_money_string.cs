using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budgeteer.Domain.Currency;
using Machine.Specifications;

namespace Budgeteer.mspec.Import.Parsers.for_MoneyParser
{
    class when_passing_a_valid_money_string : given.a_MoneyParser
    {
        private Establish context = () =>
        {
            InputValue = "kr 1 050,00";
            Expected = new Money() { Value = 1050.00m };
        };

        private Because of = () => Result = Parser.ParseMoney(InputValue);

        private It should_be_a_valid_sum_of_money = () => Result.Value.ShouldEqual(Expected.Value);
    }
}
