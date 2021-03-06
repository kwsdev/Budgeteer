﻿using Common.Regions;
using Modules.History.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Modules.History
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