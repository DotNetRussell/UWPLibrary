using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BasecodeLibrary.Controls.TemplateSelector
{
    public class RibbonControlDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ContextRibbonItemDataTemplate { get; set; }
        public DataTemplate ContextRibbonMenuDataTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is ContextRibbonItem)
            {
                return ContextRibbonItemDataTemplate;
            }
            else
            {
                return ContextRibbonMenuDataTemplate;
            }
        }
    }
}
