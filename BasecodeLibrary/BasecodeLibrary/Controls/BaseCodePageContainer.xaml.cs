using System;
using System.ComponentModel;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;


namespace BasecodeLibrary.Controls
{
    /// <summary>
    /// BaseCodePageContainer is used as a hook into the application to help support other BaseCodeLibrary Controls
    /// </summary>
    [ContentProperty(Name = "PageContent")]
    public partial class BaseCodePageContainer : Page, INotifyPropertyChanged
    {
        /// <summary>
        /// Sets the application full screen
        /// </summary>
        public bool IsFullScreen
        {
            get { return (bool)GetValue(IsFullScreenProperty); }
            internal set { SetValue(IsFullScreenProperty, value); }
        }

        public static readonly DependencyProperty IsFullScreenProperty =
            DependencyProperty.Register("IsFullScreen", typeof(bool), typeof(BaseCodePageContainer), new PropertyMetadata(false, OnIsFullScreenChanged));

        public static readonly DependencyProperty FullScreenObjectProperty =
            DependencyProperty.Register("FullScreenObject", typeof(Tuple<UIElement, Action<UIElement>>), typeof(BaseCodePageContainer), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The object to be displayed full screen
        /// </summary>
        internal Tuple<UIElement, Action<UIElement>> FullScreenObject
        {
            get { return (Tuple<UIElement, Action<UIElement>>)GetValue(FullScreenObjectProperty); }
            set { SetValue(FullScreenObjectProperty, value); }
        }

        private Grid fullScreenGrid;
        private bool IsApplicationFullScreenDefault = false;

        /// <summary>
        /// The page's content 
        /// </summary>
        public UIElement PageContent
        {
            get { return (UIElement)GetValue(PageContentProperty); }
            set { SetValue(PageContentProperty, value); }
        }

        public static readonly DependencyProperty PageContentProperty =
            DependencyProperty.Register("PageContent", typeof(UIElement), typeof(BaseCodePageContainer), new PropertyMetadata(null, OnContentChanged));
      
        /// <summary>
        /// BaseCodePageContainer Constructor
        /// </summary>
        public BaseCodePageContainer()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackButtonPressed;
            IsApplicationFullScreenDefault = ApplicationView.GetForCurrentView().IsFullScreenMode;
        }

        /// <summary>
        /// Displays an error message to the user
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="title">Title of the error message</param>
        public static async void DispalyErrorMessage(string message, string title = "An error has occured")
        {
            MessageDialog dialog = new MessageDialog(message, title);            
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Handles when the user presses the back button and the screen is set to full screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBackButtonPressed(object sender, BackRequestedEventArgs e)
        {
            if (IsFullScreen)
            {
                IsFullScreen = false;
                fullScreenGrid.Children.Remove(FullScreenObject.Item1);
                FullScreenObject.Item2.Invoke(FullScreenObject.Item1);
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Toggles the fullscreen functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void OnIsFullScreenChanged(Object sender, DependencyPropertyChangedEventArgs args)
        {
            BaseCodePageContainer container = sender as BaseCodePageContainer;
            if (container != null)
            {
                ToggleFullScreen(container);
            }
        }

        /// <summary>
        /// Handles setting the page content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void OnContentChanged(Object sender, DependencyPropertyChangedEventArgs args)
        {
            BaseCodePageContainer container = sender as BaseCodePageContainer;
            if (container != null)
            {
                container.Content = container.PageContent;
            }
        }

        /// <summary>
        /// Toggles between full screen and standard screen sizes
        /// </summary>
        /// <param name="container"></param>
        private static void ToggleFullScreen(BaseCodePageContainer container)
        {
            if (container.IsFullScreen)
            {
                if (container.FullScreenObject != null)
                {
                    ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
                    container.fullScreenGrid = new Grid();
                    container.fullScreenGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                    container.fullScreenGrid.VerticalAlignment = VerticalAlignment.Stretch;

                    Button exitFullScreenButton = new Button() { Content = "Exit Fullscreen" };
                    exitFullScreenButton.Click += (s, a) => 
                    {
                        container.IsFullScreen = false;
                        container.fullScreenGrid.Children.Remove(container.FullScreenObject.Item1);
                        container.FullScreenObject.Item2.Invoke(container.FullScreenObject.Item1);
                    };
                    GridLength gl1 = new GridLength(.95, GridUnitType.Star);
                    GridLength gl2 = new GridLength(.05, GridUnitType.Star);

                    container.fullScreenGrid.RowDefinitions.Add(new RowDefinition() { Height = gl1});
                    container.fullScreenGrid.RowDefinitions.Add(new RowDefinition() { Height = gl2 });
                    
                    Grid.SetRow(container.FullScreenObject.Item1 as FrameworkElement, 0);
                    Grid.SetRow(exitFullScreenButton, 1);                   
                    
                    container.fullScreenGrid.Children.Add(container.FullScreenObject.Item1);
                    container.fullScreenGrid.Children.Add(exitFullScreenButton);

                    container.Content = container.fullScreenGrid;
                }
            }
            else
            {
                if (container.PageContent != null)
                {
                    if (!container.IsApplicationFullScreenDefault)
                    {
                        ApplicationView.GetForCurrentView().ExitFullScreenMode();
                    }
                    container.Content = container.PageContent;
                }
            }
        }

        /// <summary>
        /// OnPropertyChanged handler for the BaseCodePageContainer class
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
