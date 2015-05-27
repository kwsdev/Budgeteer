using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Budgeteer.Intro
{
    [ImplementPropertyChanged]
    public class CreateOrOpenViewModel
    {
        public string BudgetName { get; set; }
        
        public bool ShowCreatePanel { get; set; }

        public bool ShowOpenPanel { get; set; }

        public string ExistingBudgetPath { get; set; }
    }
}
