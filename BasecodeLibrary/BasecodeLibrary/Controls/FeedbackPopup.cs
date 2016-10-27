using BasecodeLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using static BasecodeLibrary.Utilities.ApplicationServices;

namespace BasecodeLibrary.Controls
{
    [TemplatePart(Name = "PART_FeedbackMessageContainer", Type = typeof(Border))]
    [TemplatePart(Name = "PART_FeedbackTitle", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_FeedbackContent", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_FeedbackButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
    public class FeedbackPopup : PopupBase
    {
        private const string DEFAULT_TITLE = "Have Your Voice Heard | Leave Feedback!";
        private const string DEFAULT_CONTENT = "Please let me know how you like the app or if you are having any issues with it.";

        private Border _partFeedbackMessageContainer;
        private TextBlock _partFeedbackTitle;
        private TextBlock _partFeedbackContent;
        private Button _partFeedbackButton;
        private Button _partCancelButton;

        public FeedbackPopup()
        {
            DeviceType device = ApplicationServices.CurrentDevice;

            if (device == DeviceType.Mobile)
            {
                DefaultStyleKey = typeof(FeedbackPopupMobile);
            }
            else
            {
                DefaultStyleKey = typeof(FeedbackPopup);
            }

            PopupTitle = DEFAULT_TITLE;
            PopupContent = DEFAULT_CONTENT;
        }

        protected override void OnApplyTemplate()
        {
            _partFeedbackMessageContainer = GetTemplateChild("PART_FeedbackMessageContainer") as Border;
            _partFeedbackTitle = GetTemplateChild("PART_FeedbackTitle") as TextBlock;
            _partFeedbackContent = GetTemplateChild("PART_FeedbackContent") as TextBlock;
            _partFeedbackButton = GetTemplateChild("PART_FeedbackButton") as Button;
            _partCancelButton = GetTemplateChild("PART_CancelButton") as Button;

            if (_partFeedbackButton != null)
            {
                _partFeedbackButton.Click += async (s, a) =>
                {
                    EmailMessage emailMessage = new EmailMessage()
                    {                        
                        Subject = "App Feedback " + Package.Current.DisplayName + " " + ApplicationServices.CurrentDevice,
                    };

                    emailMessage.To.Add(new EmailRecipient() { Address = "admin@DotNetRussell.com" });
                    await EmailManager.ShowComposeNewEmailAsync(emailMessage);
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

        public static void LoadFeedback()
        {
            EmailMessage emailMessage = new EmailMessage()
            {
                Subject = "App Feedback " + Package.Current.DisplayName + " " + ApplicationServices.CurrentDevice,
            };

            emailMessage.To.Add(new EmailRecipient() { Address = "admin@DotNetRussell.com" });
            EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

    }

    public class FeedbackPopupMobile : FeedbackPopup
    {
        public FeedbackPopupMobile()
        {
            DefaultStyleKey = typeof(FeedbackPopupMobile);
        }
    }

   
}
