using System.IO;
using Common.Domain;
using SparebankenSor.Import.Parsers;

namespace SparebankenSor.Import.Importers
{
    public class CsvImporter
    {
        private readonly DateParser _dateParser;
        private readonly DirectionParser _directionParser;
        private readonly MoneyParser _moneyParser;

        public CsvImporter(MoneyParser moneyParser, DirectionParser directionParser, DateParser dateParser)
        {
            _moneyParser = moneyParser;
            _directionParser = directionParser;
            _dateParser = dateParser;
        }

        public AccountHistory ImportAccountHistoryFromFile(string path)
        {
            return BuildAccountHistoryFromFile(path);
        }

        private AccountHistory BuildAccountHistoryFromFile(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            var accountHistory = new AccountHistory();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                accountHistory.Entries.Add(BuildHistoryEntry(line));
            }

            return accountHistory;
        }

        private HistoryEntry BuildHistoryEntry(string line)
        {
            var values = line.Split(';');

            var date = _dateParser.ParseDate(values[0]);
            var description = values[1];
            var direction = _directionParser.ParseDirection(values[2], values[3]);
            var amount = _moneyParser.ParseMoney(direction == TransferDirection.Withdrawal ? values[2] : values[3]);

            var entry = new HistoryEntry
            {
                Date = date,
                Description = description,
                Direction = direction,
                Amount = amount
            };

            return entry;
        }
    }
}