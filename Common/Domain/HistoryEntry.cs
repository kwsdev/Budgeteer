using System;
using Common.Domain.Currency;

namespace Common.Domain
{
    public class HistoryEntry
    {
        public DateTime Date { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public TransferDirection Direction { get; set; }

        public Money Amount { get; set; }

        public int Ref { get; set; }

        public ExternalAccount ExternalAccount { get; set; }
    }
}