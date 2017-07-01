namespace Common.Domain
{
    public class ExternalAccount : Account
    {
        public ExternalAccount(AccountId id, AccountNumber number) : base(id, number)
        {
        }
    }
}