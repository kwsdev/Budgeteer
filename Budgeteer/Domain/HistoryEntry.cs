using System;
using Budgeteer.Domain.Currency;

namespace Budgeteer.Domain
{
    public class HistoryEntry
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TransferDirection Direction { get; set; }
        public Money Amount { get; set; }
    }
}