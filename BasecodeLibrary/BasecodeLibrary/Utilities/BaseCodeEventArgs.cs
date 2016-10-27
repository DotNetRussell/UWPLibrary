using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace BasecodeLibrary.Utilities
{
    public class BaseCodeEventArgs : RoutedEventArgs, IBasecodeEventArgs
    {
        private object _value;
        public object Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }
    }
}
