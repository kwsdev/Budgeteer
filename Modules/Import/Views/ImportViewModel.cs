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

        public ImportViewModel(CsvImporter csvImporter)
        {
            _csvImporter = csvImporter;
            this.ImportCommand = new DelegateCommand(OpenSelectFileDialog);
        }

        private void OpenSelectFileDialog()
        {
#if DEBUG
            this.ImportTransactions(UseHardcodedPath());
#else
            this.ImportTransactiosn(SelectTextFile());
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
            return "C:\\Users\\k\\Documents\\transaksjoner-1.csv";
        }

        public ICommand ImportCommand { get; }

        public AccountHistory ImportTransactions(string path)
        {
            return _csvImporter.ImportAccountHistoryFromFile(path);
        }
    }
}