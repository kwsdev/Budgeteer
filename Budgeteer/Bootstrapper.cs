using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using Features.History;
using Common.ExtensionMethods;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Budgeteer
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            SetupViewModelLocatorConvention();
            ConfigureDependencyInjectionWithViewModelLocator();

            base.Run(runWithDefaultConfiguration);
        }

        protected override IUnityContainer CreateContainer()
        {
            return new UnityContainer();
        }

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



        private void ConfigureDependencyInjectionWithViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory((type) =>
            {
                return Container.Resolve(type);
            });
        }

        private static void SetupViewModelLocatorConvention()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var shortViewName = viewName.TrimEnd("View");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", shortViewName,
                    viewAssemblyName);
                return Type.GetType(viewModelName);
            });
        }
    }
}