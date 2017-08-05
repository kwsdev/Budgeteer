using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Common.Domain;
using GjensidigeBank.Import;
using Microsoft.Win32;
using Prism.Commands;
using PropertyChanged;

namespace Modules.Import.Views
{
    public class ImportViewModel
    {
        private readonly CsvImporter _csvImporter;
        private readonly IHistoryRegistry _historyRegistry;

        public ImportViewModel(CsvImporter csvImporter, IHistoryRegistry historyRegistry)
        {
            _csvImporter = csvImporter;
            _historyRegistry = historyRegistry;
            this.ImportCommand = new DelegateCommand(OpenSelectFileDialog);
        }

        private void OpenSelectFileDialog()
        {
#if DEBUG
            _historyRegistry.Register(this.ImportTransactions(UseHardcodedPath()));
#else
            _historyRegistry.Register(this.ImportTransactiosn(SelectTextFile()));
#endif
        }

        public string SelectTextFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.DefaultExt = "*.csv";

            dialog.ShowDialog();

            return dialog.FileName;
        }

        public string UseHardcodedPath()
        {
            return "..\\..\\..\\transaksjoner.csv";
        }

        public ICommand ImportCommand { get; }

        public AccountHistory ImportTransactions(string path)
        {
            return _csvImporter.ImportAccountHistoryFromFile(path);
        }
    }
}