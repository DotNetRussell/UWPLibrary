using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace BasecodeLibrary.Controls
{
    /// <summary>
    /// This class is the main BaseCodeLibrary control container
    /// It contains top level control functionality
    /// </summary>
    [ContentProperty(Name = "ControlContent")]
    public class ControlContainer : Control, INotifyPropertyChanged
    {
        /// <summary>
        /// IsBusy toggles the busy indicator for the entire control 
        /// </summary>
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool), typeof(ControlContainer), new PropertyMetadata(false, OnIsBusyChanged));

        /// <summary>
        /// Content contained inside of this container
        /// </summary>
        public UIElement ControlContent
        {
            get { return (UIElement)GetValue(ControlContentProperty); }
            set { SetValue(ControlContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlContentProperty =
            DependencyProperty.Register("ControlContent", typeof(UIElement), typeof(ControlContainer), new PropertyMetadata(null));

        public event EventHandler IsBusyChanged;

        /// <summary>
        /// Toggles the busy indicator for the control container
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void OnIsBusyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ControlContainer pageContainer = obj as ControlContainer;
            if (pageContainer != null)
            {
                bool isBusy = pageContainer.IsBusy;
                pageContainer.IsEnabled = !isBusy;

                if (pageContainer.IsBusyChanged != null)
                {
                    pageContainer.IsBusyChanged(obj, new EventArgs());
                }
            }
        }

        public void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
