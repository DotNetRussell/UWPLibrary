
using BasecodeLibrary.Interfaces;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace BasecodeLibrary.Controls
{
    public class ContextRibbonMenu : Button, IContextRibbonItem
    {
        public ObservableCollection<ContextRibbonMenuItem> ContentItems
        {
            get { return (ObservableCollection<ContextRibbonMenuItem>)GetValue(ContentItemsProperty); }
            set { SetValue(ContentItemsProperty, value); }
        }

        public static readonly DependencyProperty ContentItemsProperty =
            DependencyProperty.Register("ContentItems",
                typeof(ObservableCollection<ContextRibbonMenuItem>), typeof(ContextRibbonMenu),
                new PropertyMetadata(new ObservableCollection<ContextRibbonMenuItem>(), OnContentChanged));
        
        public ContextRibbonMenu()
        {
            DefaultStyleKey = typeof(ContextRibbonMenu);
        }
        
        private static void OnContentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
