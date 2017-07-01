using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Budgeteer.Intro;
using Common.ExtensionMethods;
using Common.Regions;
using Modules.History;
using Import;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;
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

        protected override Microsoft.Practices.Unity.IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRegionViewRegistry, RegionViewRegistry>();

            return container;
        }

        protected override DependencyObject CreateShell()
        {
            ////var culture = new CultureInfo("nb-NO");
            ////Current.Dispatcher.Thread.CurrentCulture = culture;
            ////Current.Dispatcher.Thread.CurrentUICulture = culture;            

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

            var moduleCatalog = (Prism.Modularity.ModuleCatalog)ModuleCatalog;

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
        }
    }
}