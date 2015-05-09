using Common.Regions;
using Features.History.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Features.History
{
    public class HistoryModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _viewRegistry;

        public HistoryModule(IRegionViewRegistry viewRegistry, IRegionManager regionManager)
        {
            _viewRegistry = viewRegistry;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.AddToRegion(RegionNames.TabRegion, new HistoryTabItemView());
        }
    }
}