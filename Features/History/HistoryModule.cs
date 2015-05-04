using Features.History.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Features.History
{
    public class HistoryModule : IModule
    {
        private readonly IRegionViewRegistry _viewRegistry;

        public HistoryModule(IRegionViewRegistry viewRegistry)
        {
            _viewRegistry = viewRegistry;
        }

        public void Initialize()
        {
            _viewRegistry.RegisterViewWithRegion("FeatureListRegion", typeof(HistoryButtonView));
            _viewRegistry.RegisterViewWithRegion("ContentRegion", typeof(HistoryView));
        }
    }
}
