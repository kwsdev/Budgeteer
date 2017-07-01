namespace Common.Domain
{
    public class InternalAccount : Account
    {
        public InternalAccount(AccountId id, AccountNumber number, Person owner) : base(id, number)
        {
            Owner = owner;
        }

        public Person Owner { get; }
    }
}