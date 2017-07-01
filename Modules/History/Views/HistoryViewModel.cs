using Common.Domain;
using Prism.Mvvm;

namespace Modules.History.Views
{
    public class HistoryViewModel : BindableBase
    {
        private AccountHistory _history;

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