using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BasecodeLibrary.Controls
{
    /// <summary>
    /// Displays a YouTube video in a .NET video player
    /// </summary>
    [TemplatePart(Name = "PART_WebViewer", Type = typeof(WebView))]
    public class YouTubeVideoPlayer : ControlContainer
    {
        private WebView _webView;
        private Grid _containerGrid;
        private Button _fullscreenButton;
        private string _embedVideo
        {
            get
            {
                return @"<iframe width='" + (PlayerWidth - 100) + @"' height='" + (PlayerHeight - 100) + @"' src='https://www.youtube-nocookie.com/embed/" + YouTubeSource + @"?rel=0&amp;controls=0&amp;showinfo=0' frameborder = '0' allowfullscreen ></iframe>";
            }
        }
        private string _fullScreenEmbed
        {
            get
            {
                return @"<iframe width='100%' height='100%' src='https://www.youtube-nocookie.com/embed/" + YouTubeSource + @"?rel=0&amp;controls=1&amp;showinfo=0' frameborder = '0' allowfullscreen = 'false' ></iframe>";
            }
        }

        /// <summary>
        /// Sets the height resolution of the video 
        /// </summary>
        public int PlayerHeight
        {
            get { return (int)GetValue(PlayerHeightProperty); }
            set { SetValue(PlayerHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerHeightProperty =
            DependencyProperty.Register("PlayerHeight", typeof(int), typeof(YouTubeVideoPlayer), new PropertyMetadata(0, OnSizeChanged));

        /// <summary>
        ///  Sets the width resolution of the video 
        /// </summary>
        public int PlayerWidth
        {
            get { return (int)GetValue(PlayerWidthProperty); }
            set { SetValue(PlayerWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerWidthProperty =
            DependencyProperty.Register("PlayerWidth", typeof(int), typeof(YouTubeVideoPlayer), new PropertyMetadata(0, OnSizeChanged));

        /// <summary>
        /// The video ID of the youtube video
        /// </summary>
        public string YouTubeSource
        {
            get { return (string)GetValue(YouTubeSourceProperty); }
            set { SetValue(YouTubeSourceProperty, value); }
        }

        public static readonly DependencyProperty YouTubeSourceProperty =
            DependencyProperty.Register("YouTubeSource", typeof(string), typeof(YouTubeVideoPlayer), new PropertyMetadata(null, OnSourceChanged));

        /// <summary>
        /// Basic constructor
        /// </summary>
        public YouTubeVideoPlayer()
        {
            DefaultStyleKey = typeof(YouTubeVideoPlayer);
        }

        protected override void OnApplyTemplate()
        {
            _fullscreenButton = GetTemplateChild("PART_FullScreenButton") as Button;
            _containerGrid = GetTemplateChild("PART_ContainerGrid") as Grid;
            _webView = GetTemplateChild("PART_WebViewer") as WebView;

            if (_webView != null)
            {
                _webView.ContentLoading += (s, a) => { IsBusy = true; };
                _webView.LoadCompleted += (s, a) =>
                {
                    IsBusy = false;
                };

                if (_webView != null)
                {
                    //This is a super hack to get the embeded video player to size correctly to the WebViewer
                    //First it loads the initial video to force the dom to a size, otherwise it's 0
                    //Then we refresh the webviewer with a frame that sets the width & height to 100% of the
                    //webviewer. This web viewer can now be passed between views and its content (the yt video)
                    //will size to what ever the webviewer is dynamically set too. This is helpfull for 
                    //going fullscreen and also for window resizing.
                    _webView.NavigateToString(_embedVideo);
                    Refresh();
                }
            }

            if (_fullscreenButton != null)
            {
                _fullscreenButton.Click += (s, a) =>
                {
                    SetFullScreen();
                };
            }
        }

        private static void OnSizeChanged(object obj, DependencyPropertyChangedEventArgs args)
        {
            YouTubeVideoPlayer player = (YouTubeVideoPlayer)obj;

            //Set the container just a little bigger than the video.
            player.Height = player.PlayerHeight + 30;
            player.Width = player.PlayerWidth + 30;
        }

        private static void OnSourceChanged(object obj, DependencyPropertyChangedEventArgs args)
        {
            YouTubeVideoPlayer player = (YouTubeVideoPlayer)obj;
            if (player._webView != null)
            {
                player.Refresh();
            }
        }

        private async void Refresh()
        {
            await Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                _webView.NavigateToString(_fullScreenEmbed);
            });
        }

        private void SetFullScreen()
        {
            object parent = VisualTreeHelper.GetParent((DependencyObject)this);
            while (parent != null)
            {
                BaseCodePageContainer container = parent as BaseCodePageContainer;
                if (container != null)
                {
                    _containerGrid.Children.Remove(_webView);
                    container.FullScreenObject = new Tuple<UIElement, Action<UIElement>>(_webView, callback =>
                    {
                        _webView = callback as WebView;
                        _containerGrid.Children.Add(_webView);
                    });

                    container.IsFullScreen = true;
                    break;
                }
                else
                {
                    parent = VisualTreeHelper.GetParent((DependencyObject)parent);
                }
            }

            if (parent == null)
            {
                throw new ArgumentException("Page must be of type BaseCodePageContainer");
            }
        }
    }
}
