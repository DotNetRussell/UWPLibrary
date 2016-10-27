using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTPlaylistsContentDetails : ModelBase, YTIContentDetails
    {
        private int _itemCount;

        public int ItemCount
        {
            get { return _itemCount; }
            set { _itemCount = value;  OnPropertyChanged("ItemCount"); }
        }
    }
}
