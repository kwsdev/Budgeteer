using Common.Domain;

namespace SparebankenSor.Import.Parsers
{
    public class DirectionParser
    {
        public TransferDirection ParseDirection(string valueOne, string valueTwo)
        {
            var isValueOneEmptry = string.IsNullOrEmpty(valueOne);
            var isValueTwoEmptry = string.IsNullOrEmpty(valueTwo);

            if (!isValueOneEmptry && isValueTwoEmptry)
            {
                return TransferDirection.Withdrawal;
            }
            if (isValueOneEmptry && !isValueTwoEmptry)
            {
                return TransferDirection.Deposit;
            }
            return TransferDirection.NotSpecified;
        }
    }
}