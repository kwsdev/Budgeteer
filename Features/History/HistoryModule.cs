using Features.History.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Features.History
{
    public class HistoryModule : IModule
    {
        private readonly IRegionViewRegistry _viewRegistry;
        private readonly IRegionManager _regionManager;

        public HistoryModule(IRegionViewRegistry viewRegistry, IRegionManager regionManager)
        {
            _viewRegistry = viewRegistry;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.AddToRegion("TabRegion", new HistoryButtonView());
            _viewRegistry.RegisterViewWithRegion("ContentRegion", typeof(HistoryView));
        }
    }
}
