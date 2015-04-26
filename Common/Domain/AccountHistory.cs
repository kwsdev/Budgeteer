using System.Collections.ObjectModel;

namespace Common.Domain
{
    public class AccountHistory
    {
        private ObservableCollection<HistoryEntry> entries;

        public ObservableCollection<HistoryEntry> Entries
        {
            get { return entries ?? (entries = new ObservableCollection<HistoryEntry>()); }
        }
    }
}