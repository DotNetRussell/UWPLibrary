using BasecodeLibrary.Interfaces;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BasecodeLibrary.Controls
{
    public class ContextRibbon : ItemsControl
    {

        /// <summary>
        /// All of the available items to filter
        /// </summary>
        public ObservableCollection<IContextRibbonItem> ContentItems
        {
            get { return (ObservableCollection<IContextRibbonItem>)GetValue(ContentItemsProperty); }
            set { SetValue(ContentItemsProperty, value); }
        }

        public static readonly DependencyProperty ContentItemsProperty =
            DependencyProperty.Register("ContentItems",
                typeof(ObservableCollection<IContextRibbonItem>), typeof(ContextRibbon),
                new PropertyMetadata(null, OnContentChanged));
        
        public ContextRibbon()
        {
            DefaultStyleKey = typeof(ContextRibbon);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        private static void OnContentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
