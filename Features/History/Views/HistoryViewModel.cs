using Common.Domain;
using Microsoft.Practices.Prism.Mvvm;

namespace Features.History.Views
{
    public class HistoryViewModel : BindableBase
    {
        private AccountHistory _history;

        public AccountHistory History
        {
            get { return _history; }


            private set
            {
                if (_history == value)
                {
                    return;
                }

                _history = value;
                OnPropertyChanged(() => History);
            }
        }

        public void Load(AccountHistory history)
        {
            History = history;
        }
    }
}