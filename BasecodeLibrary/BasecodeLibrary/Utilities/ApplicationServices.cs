using Windows.UI.ViewManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using System.Diagnostics;
using Windows.Storage;
using Windows.ApplicationModel;
using System.Runtime.Serialization;
using System.IO;

namespace BasecodeLibrary.Utilities
{
    public static class ApplicationServices
    {
        private static Dictionary<string, object> _ApplicationCache = new Dictionary<string, object>();

        public enum DeviceType
        {
            Desktop = 0,
            Phablet = 1,
            Mobile = 2
        }      

        public static DeviceType CurrentDevice
        {
            get
            {
                ApplicationView view = ApplicationView.GetForCurrentView();
                Rect rect = view.VisibleBounds;

                if (rect.Width >= 1024)
                {
                    return DeviceType.Desktop;
                }
                else if (rect.Width >= 720)
                {
                    return DeviceType.Phablet;
                }
                else
                {
                    return DeviceType.Mobile;
                }
            }
        }

        public static void AddItemToApplicationCache(string itemKey, object itemValue)
        {
            if (!_ApplicationCache.ContainsKey(itemKey))
            {
                _ApplicationCache.Add(itemKey, itemValue);
            }
            else
            {
                _ApplicationCache.Remove(itemKey);
                _ApplicationCache.Add(itemKey, itemValue);
            }
        }

        public static object GetItemFromApplicationCache(string itemKey)
        {
            object retValue;

            _ApplicationCache.TryGetValue(itemKey, out retValue);

            Debug.WriteLineIf(retValue == null, "The item with key " + itemKey + " was not found.");

            return retValue;
        }

        public static bool ApplicationCacheContains(string itemKey)
        {
            return GetItemFromApplicationCache(itemKey) != null;
        }


    }

    

   
}
