using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTVideoContentDetails : ModelBase, YTIContentDetails
    {
        private string _videoId;

        public string VideoId
        {
            get { return _videoId; }
            set { _videoId = value; OnPropertyChanged("VideoId"); }
        }
    }
}
