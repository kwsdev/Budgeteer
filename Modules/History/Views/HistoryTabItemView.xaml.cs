using System.Windows.Controls;
using Microsoft.Practices.Prism.Mvvm;

namespace Modules.History.Views
{
    /// <summary>
    ///     Interaction logic for HistoryTabItemView.xaml
    /// </summary>
    public partial class HistoryTabItemView : TabItem, IView
    {
        public HistoryTabItemView()
        {
            InitializeComponent();
        }
    }
}