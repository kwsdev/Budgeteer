using System;
using System.Linq;
using Common.Domain;
using Prism.Mvvm;

namespace Modules.History.Views
{
    public class HistoryViewModel : BindableBase
    {
        private readonly HistoryRegistry _registry;
        private AccountHistory _history;

        public HistoryViewModel(HistoryRegistry registry)
        {
            _registry = registry;
            _registry.RegistryUpdatedEvent += RegistryOnRegistryUpdatedEvent;
        }

        private void RegistryOnRegistryUpdatedEvent(object sender, EventArgs eventArgs)
        {
            this.Load(_registry.AccountHistories.First());
        }

        public AccountHistory Entries
        {
            get => _history;


            private set
            {
                if (_history == value)
                {
                    return;
                }

                _history = value;
                RaisePropertyChanged();
            }
        }

        public void Load(AccountHistory history)
        {
            Entries = history;
        }
    }
}