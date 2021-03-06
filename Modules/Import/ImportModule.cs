﻿using Common.Regions;
using Modules.Import.Views;
using Prism.Modularity;
using Prism.Regions;

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
        }
    }
}