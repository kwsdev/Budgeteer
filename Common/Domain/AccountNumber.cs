namespace Common.Domain
{
    public class AccountNumber
    {
        public AccountNumber(string number)
        {
            Number = number;
        }

        public string Number { get; }
    }
}