using System.Globalization;
using System.Windows;

namespace Budgeteer
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var culture = new CultureInfo("nb-NO");
            Current.Dispatcher.Thread.CurrentCulture = culture;
            Current.Dispatcher.Thread.CurrentUICulture = culture;
        }
    }
}