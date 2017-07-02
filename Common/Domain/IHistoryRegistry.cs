namespace Common.Domain
{
    public interface IHistoryRegistry
    {
        void Register(AccountHistory accountHistory);
    }
}