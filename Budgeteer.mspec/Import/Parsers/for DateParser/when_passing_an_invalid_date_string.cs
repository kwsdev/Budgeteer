﻿using System;
using Budgeteer.mspec.Import.Parsers.for_DateParser.given;
using Machine.Specifications;

namespace Budgeteer.mspec.Import.Parsers.for_DateParser
{
    internal class when_passing_an_invalid_date_string : a_DateParser
    {
        private Establish context = () =>
        {
            inputValue = "fdasfas";
            expected = DateTime.MinValue;
        };

        private Because of = () => result = Parser.ParseDate(inputValue);
        private It should_return_a_default_value = () => result.ShouldEqual(expected);
    }
}