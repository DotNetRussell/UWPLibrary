using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace BasecodeLibrary.Controls
{
    [TemplatePart(Name = "PART_PopupTitle", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_PopupContent", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_OkayButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FadeInAnimation", Type = typeof(Storyboard))]
    public class PopupBase : ControlContainer
    {
        private const string POPUP_TITLE = "This is a title - To change, set the PopupTitle Property";
        private const string POPUP_CONTENT = "This is the content - To change, stet the PopupContent Property";

        private TextBlock _partPopupTitle;
        private TextBlock _partPopupContent;
        private Button _partOkayButton;
        private Button _partCancelButton;
        private Storyboard _FadeInAnimation;

        /// <summary>
        /// Text that appears in the header of the popup
        /// </summary>
        public string PopupTitle
        {
            get { return (string)GetValue(PopupTitleProperty); }
            set { SetValue(PopupTitleProperty, value); }
        }
        
        public static readonly DependencyProperty PopupTitleProperty =
            DependencyProperty.Register("PopupTitle", typeof(string), typeof(PopupBase), new PropertyMetadata(POPUP_TITLE));

        /// <summary>
        /// Text that appears within the popup
        /// </summary>
        public string PopupContent
        {
            get { return (string)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }

        public static readonly DependencyProperty PopupContentProperty =
            DependencyProperty.Register("PopupContent", typeof(string), typeof(PopupBase), new PropertyMetadata(POPUP_CONTENT));

        public PopupBase()
        {
            DefaultStyleKey = typeof(PopupBase);
            Visibility = Visibility.Collapsed;

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackButtonPressed;
        }

        private void OnBackButtonPressed(object sender, BackRequestedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                HidePopup();
                e.Handled = true;
            }
        }

        protected override void OnApplyTemplate()
        {
            _partPopupTitle = GetTemplateChild("PART_PopupTitle") as TextBlock;
            _partPopupContent = GetTemplateChild("PART_PopupContent") as TextBlock;
            _partOkayButton = GetTemplateChild("PART_OkayButton") as Button;
            _partCancelButton = GetTemplateChild("PART_CancelButton") as Button;
            _FadeInAnimation = GetTemplateChild("PART_FadeInAnimation") as Storyboard;

            if (_FadeInAnimation != null)
            {
                _FadeInAnimation.Begin();
            }
            if (_partOkayButton != null)
            {
                _partOkayButton.Click += (s, a) =>
                {
                    HidePopup();
                };
            }
            if (_partCancelButton != null)
            {
                _partCancelButton.Click += (s, a) =>
                {
                    HidePopup();
                };
            }

            base.OnApplyTemplate();
        }

        /// <summary>
        /// Displays the popup
        /// </summary>
        public virtual void ShowPopup()
        {
            Visibility = Visibility.Visible;

            if (_FadeInAnimation != null)
            {
                _FadeInAnimation.Begin();
            }
        }

        internal virtual void HidePopup()
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
