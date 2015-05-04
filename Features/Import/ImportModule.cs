using Common.Regions;
using Import.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Import
{
    public class ImportModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegionViewRegistry _viewRegistry;

        public ImportModule(IRegionViewRegistry viewRegistry, IRegionManager regionManager)
        {
            _viewRegistry = viewRegistry;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.AddToRegion(RegionNames.TabRegion, new ImportTabItemView());
            _viewRegistry.RegisterViewWithRegion(RegionNames.ContentRegion, typeof (ImportView));
        }
    }
}