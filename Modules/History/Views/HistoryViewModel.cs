using System;
using System.Collections.ObjectModel;
using System.Linq;
using Common.Domain;
using Prism.Mvvm;

namespace Modules.History.Views
{
    public class HistoryViewModel : BindableBase
    {
        private readonly HistoryRegistry _registry;

        public HistoryViewModel(HistoryRegistry registry)
        {
            _registry = registry;
            _registry.RegistryUpdatedEvent += RegistryOnRegistryUpdatedEvent;
        }

        private void RegistryOnRegistryUpdatedEvent(object sender, EventArgs eventArgs)
        {
            this.Load(_registry.AccountHistories.First());
        }

        public ObservableCollection<HistoryEntry> Entries { get; private set; }

        public void Load(AccountHistory history)
        {
           Entries = new ObservableCollection<HistoryEntry>(history.Entries);
        }
    }
}