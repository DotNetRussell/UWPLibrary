using BasecodeLibrary.SerializableObjects;
using BasecodeLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static BasecodeLibrary.Utilities.ApplicationServices;

namespace BasecodeLibrary.Controls
{
    [TemplatePart(Name = "PART_RateAppButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_HateAppButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_StopReminding", Type = typeof(CheckBox))]
    public class RateReminder : PopupBase
    {
        private const string TITLE = "Love it or Hate, it don't forget to Rate it!";
        private const string CONTENT = "Hey, do you really like this app?\r\nMaybe you hate it!\r\nEither way let me know so I can continue to improve!";

        private Button _partRateAppButton;
        private Button _partHateAppBuston;
        private Button _partCloseButton;
        private CheckBox _partStopRemindingCheckBox;
        private FeedbackPopup _partFeedback;

        public int ReminderTrigger
        {
            get { return (int)GetValue(ReminderTriggerProperty); }
            set { SetValue(ReminderTriggerProperty, value); }
        }

        public static readonly DependencyProperty ReminderTriggerProperty =
            DependencyProperty.Register("ReminderTrigger", typeof(int), typeof(RateReminder), new PropertyMetadata(3));

        private bool IsDontShowChecked { get; set; }

        public RateReminder()
        {
            PopupTitle = TITLE;
            PopupContent = CONTENT;

            DeviceType device = ApplicationServices.CurrentDevice;

            if (device == DeviceType.Mobile)
            {
                DefaultStyleKey = typeof(RateReminderMobile);
            }
            else
            {
                DefaultStyleKey = typeof(RateReminder);
            }

            CheckRateReminder();
        }

        protected override void OnApplyTemplate()
        {
            _partRateAppButton = GetTemplateChild("PART_RateAppButton") as Button;
            _partHateAppBuston = GetTemplateChild("PART_HateAppButton") as Button;
            _partCloseButton = GetTemplateChild("PART_CloseButton") as Button;
            _partStopRemindingCheckBox = GetTemplateChild("PART_StopReminding") as CheckBox;
            _partFeedback = GetTemplateChild("PART_Feedback") as FeedbackPopup;

            PostApplyTemplate();
            base.OnApplyTemplate();
        }

        private void PostApplyTemplate()
        {
            if(_partRateAppButton != null)
            {
                _partRateAppButton.Click += async (s, a) => 
                {
                    await Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}", 
                        Windows.ApplicationModel.Package.Current.Id.FamilyName)));
                };
            }
            if(_partHateAppBuston != null)
            {
                _partHateAppBuston.Click += async (s, a) => 
                {
                    EmailMessage emailMessage = new EmailMessage()
                    {
                        Subject = "App Feedback " + Package.Current.DisplayName + " " + ApplicationServices.CurrentDevice,
                    };

                    emailMessage.To.Add(new EmailRecipient() { Address = "admin@DotNetRussell.com" });
                    await EmailManager.ShowComposeNewEmailAsync(emailMessage);
                };
            }
            if (_partCloseButton != null)
            {
                _partCloseButton.Click += (s, a) => 
                {
                    HidePopup();
                };
            }
            if (_partStopRemindingCheckBox != null)
            {
                _partStopRemindingCheckBox.Checked += (s, a) => 
                {
                    IsDontShowChecked = (bool)_partStopRemindingCheckBox.IsChecked;
                    UpdateRateReminder(IsDontShowChecked);
                };
            }
        }

        private void CheckRateReminder()
        {
            RateReminderSaveObject reminderSaveObject;

            if (SaveManager.SaveObjectExists(RateReminderSaveObject.ObjectName, typeof(RateReminderSaveObject)))
            {
                reminderSaveObject =
                     (RateReminderSaveObject)SaveManager.GetObject(RateReminderSaveObject.ObjectName,
                    typeof(RateReminderSaveObject));
                reminderSaveObject.RunTimes++;
            }
            else
            {
                reminderSaveObject = new RateReminderSaveObject() { Flag = false };
                reminderSaveObject.RunTimes++;        
            }

            SaveManager.SaveObject(reminderSaveObject);

            if (!reminderSaveObject.Flag && reminderSaveObject.RunTimes % ReminderTrigger == 0)
            {
                ShowPopup();
            }
        }

        private void UpdateRateReminder(bool newValue)
        {
            RateReminderSaveObject reminderSaveObject;

            if (SaveManager.SaveObjectExists(RateReminderSaveObject.ObjectName, typeof(RateReminderSaveObject)))
            {
                reminderSaveObject =
                     (RateReminderSaveObject)SaveManager.GetObject(RateReminderSaveObject.ObjectName,
                    typeof(RateReminderSaveObject));

                reminderSaveObject.Flag = newValue;

                SaveManager.OverWriteSaveObject(reminderSaveObject);
            }
        }
    }

    public class RateReminderMobile : RateReminder
    {
        public RateReminderMobile()
        {
            DefaultStyleKey = typeof(RateReminderMobile);
        }      
    }
}
