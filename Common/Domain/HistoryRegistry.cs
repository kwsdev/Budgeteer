using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeakEvent;

namespace Common.Domain
{
    public class HistoryRegistry : IHistoryRegistry
    {
        private readonly WeakEventSource<EventArgs> _registryUpdatedSource = new WeakEventSource<EventArgs>();
        private readonly IList<AccountHistory> _histories;

        public HistoryRegistry()
        {
            _histories = new List<AccountHistory>();
        }

        public void Register(AccountHistory accountHistory)
        {
            _histories.Add(accountHistory);
            _registryUpdatedSource.Raise(this, new EventArgs());
        }

        public IEnumerable<AccountHistory> AccountHistories => _histories;

        public event EventHandler<EventArgs> RegistryUpdatedEvent
        {
            add => _registryUpdatedSource.Subscribe(value);
            remove => _registryUpdatedSource.Unsubscribe(value);
        }

    }
}
