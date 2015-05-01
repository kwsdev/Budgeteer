using System.Windows;
using Features.History;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Budgeteer
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            ////var culture = new CultureInfo("nb-NO");
            ////Current.Dispatcher.Thread.CurrentCulture = culture;
            ////Current.Dispatcher.Thread.CurrentUICulture = culture;            

            return Container.Resolve<PrismAppShell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (PrismAppShell) Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog) this.ModuleCatalog;

            moduleCatalog.AddModule(typeof(HistoryModule));
        }
    }
}