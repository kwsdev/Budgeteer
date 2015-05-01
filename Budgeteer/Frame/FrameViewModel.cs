using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Features.History.Views;
using Microsoft.Practices.Prism.Mvvm;
using SparebankenSor.Import.Importers;
using SparebankenSor.Import.Parsers;

namespace Budgeteer.Frame
{
    public class FrameViewModel : BindableBase
    {
        public UserControl currentView;
        public IEnumerable<UserControl> Views { get; private set; }

        public UserControl CurrentView
        {
            get { return currentView; }

            set
            {
                if (currentView == value)
                {
                    return;
                }

                currentView = value;
                OnPropertyChanged(() => CurrentView);
            }
        }

        public void Loaded()
        {
            Views = new List<UserControl>
            {
                new HistoryView()
            };

            CurrentView = Views.First();

            var historyViewModel = (HistoryViewModel) CurrentView.DataContext;

            historyViewModel.Load(null, new CsvImporter(new MoneyParser(), new DirectionParser(), new DateParser()));
        }
    }
}