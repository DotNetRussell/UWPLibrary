using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace BasecodeLibrary.Utilities
{
    /// <summary>
    /// Base class for all view models
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// View model OnPropertyChanged handler
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                });
            }
        }

        /// <summary>
        /// View model PropertyChanged event 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
