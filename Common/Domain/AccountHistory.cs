using System.Collections.ObjectModel;

namespace Common.Domain
{
    public class AccountHistory
    {
        private ObservableCollection<HistoryEntry> _entries;

        public AccountHistory(InternalAccount account)
        {
            Account = account;
        }

        public InternalAccount Account { get; }

        public ObservableCollection<HistoryEntry> Entries => _entries ?? (_entries = new ObservableCollection<HistoryEntry>());
    }
}