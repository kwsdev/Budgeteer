using System.ComponentModel;
using System.Windows;

namespace Common.DesignMode
{
    public static class DesignModeChecker
    {
        public static bool IsInDesignMode
        {
            get
            {
                return !DesignerProperties.GetIsInDesignMode(new DependencyObject());
            }
        }
    }
}