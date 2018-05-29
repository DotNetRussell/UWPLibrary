using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace BasecodeLibrary.Controls
{
    [ContentProperty(Name = "Items")]
    public class SettingItemSelector : SettingItem
    {
        public List<string> Items
        {
            get { return (List<string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(List<string>), typeof(SettingItemSelector), new PropertyMetadata(new List<string>()));

    }
}
