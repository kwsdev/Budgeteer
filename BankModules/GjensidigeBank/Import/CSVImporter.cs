using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace GjensidigeBank.Import
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
            var reader = new StreamReader(File.OpenRead(path), Encoding.GetEncoding(1252));

            var accountHistory = new AccountHistory(new InternalAccount(new AccountId("id"), new AccountNumber("1231"), new Person("name")));

            var isHeaderLine = false;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (!isHeaderLine)
                {
                    isHeaderLine = true;
                    continue;
                }

                accountHistory.Entries.Add(BuildHistoryEntry(line));
            }

            return accountHistory;
        }

        private HistoryEntry BuildHistoryEntry(string line)
        {
            var values = line.Split(',');

            var logDate = _dateParser.ParseDate(values[0]);
            var date = _dateParser.ParseDate(values[1]);
            var code = values[2];
            var description = values[3];
            var amount = _moneyParser.ParseMoney(values[4]);
            var direction = amount.Value > 0 ? TransferDirection.Deposit : TransferDirection.Withdrawal;
            var archiveRef = values[5];
            var externalAccountRef = values[6];
            var externalAccountId = values[7];

            var entry = new HistoryEntry
            {
                LogDate = logDate,
                Date = date,
                Description = description,
                Direction = direction,
                Amount = amount,
                Code = code,
                ArchiveRef = archiveRef,
                ExternalAccount = new ExternalAccount(new AccountId(externalAccountRef), new AccountNumber(externalAccountId)),
            };

            return entry;
        }
    }
}
