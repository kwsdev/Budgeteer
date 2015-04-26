using System.Windows;

namespace Budgeteer.Frame
{
    /// <summary>
    ///     Interaction logic for FrameView.xaml
    /// </summary>
    public partial class FrameView : Window
    {
        public FrameView()
        {
            InitializeComponent();

            Loaded += FrameView_Loaded;
        }

        public void FrameView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as FrameViewModel;
            vm.Loaded();
        }
    }
}