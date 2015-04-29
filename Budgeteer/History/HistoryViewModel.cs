using System;
using System.Windows.Input;
using Common.Domain;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Win32;
using SparebankenSor.Import.Importers;

namespace Budgeteer.History
{
    public class HistoryViewModel : BindableBase
    {
        private CsvImporter _csvImporter;
        private AccountHistory _history;
        private ICommand _importCommand;

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

        public ICommand ImportCommand
        {
            get { return _importCommand ?? (_importCommand = new DelegateCommand(Import)); }
        }

        public void Load(AccountHistory history, CsvImporter csvImporter)
        {
            History = history;
            _csvImporter = csvImporter;
        }

        private void Import()
        {
            var fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = Environment.CurrentDirectory;

            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                var path = fileDialog.FileName;
                History = _csvImporter.ImportAccountHistoryFromFile(path);
            }
        }
    }
}