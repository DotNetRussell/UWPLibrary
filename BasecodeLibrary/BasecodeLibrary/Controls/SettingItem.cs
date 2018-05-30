using BasecodeLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using static BasecodeLibrary.Enums.BasecodeEnums;

namespace BasecodeLibrary.Controls
{
    public class SettingItem : ControlContainer
    {
        /// <summary>
        /// The label text that will be displayed left of your input setting.
        /// </summary>
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(SettingItem), new PropertyMetadata(String.Empty));

        /// <summary>
        /// The type of input that you'd like. 
        /// DEFAULT: String
        /// </summary>
        public SettingsType SettingType
        {
            get { return (SettingsType)GetValue(SettingTypeProperty); }
            set { SetValue(SettingTypeProperty, value); }
        }

        public static readonly DependencyProperty SettingTypeProperty =
            DependencyProperty.Register("SettingType", typeof(BasecodeEnums.SettingsType), typeof(SettingItem), new PropertyMetadata(SettingsType._string));

        /// <summary>
        /// The databinding path.
        /// Example: BindingPath="SomePropertyInYourDataContext"
        /// </summary>
        public string BindingPath
        {
            get { return (string)GetValue(BindingPathProperty); }
            set { SetValue(BindingPathProperty, value); }
        }

        public static readonly DependencyProperty BindingPathProperty =
            DependencyProperty.Register("BindingPath", typeof(string), typeof(SettingItem), new PropertyMetadata(String.Empty));
        
        public string ToolTip
        {
            get { return (string)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }

        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register("ToolTip", typeof(string), typeof(SettingItem), new PropertyMetadata(String.Empty));

    }
}
