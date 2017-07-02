using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Budgeteer.Intro;
using Common.Domain;
using Common.ExtensionMethods;
using Common.Regions;
using Modules.History;
using Import;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions.Behaviors;
using Prism.Unity;

namespace Budgeteer
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            SetupViewModelNamingConvention();
            ConfigureDependencyInjectionWithViewModelLocator();

            base.Run(runWithDefaultConfiguration);
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<PrismAppShellView>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current.MainWindow = (PrismAppShellView)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var moduleCatalog = (ModuleCatalog)ModuleCatalog;

            moduleCatalog.AddModule(typeof(HistoryModule));
            moduleCatalog.AddModule(typeof(ImportModule));
        }

        private void ConfigureDependencyInjectionWithViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));
        }

        private static void SetupViewModelNamingConvention()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName;
                var shortViewName = viewName.TrimEnd("View");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", shortViewName, viewAssemblyName);
                return Type.GetType(viewModelName);
            });
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            var regionManager = this.Container.Resolve<Prism.Regions.RegionManager>();
            regionManager.AddToRegion(RegionNames.TabRegion, new CreateOrOpenViewTabItemView());

            Container.RegisterType<IHistoryRegistry, HistoryRegistry>(new ContainerControlledLifetimeManager());
        }
    }
}