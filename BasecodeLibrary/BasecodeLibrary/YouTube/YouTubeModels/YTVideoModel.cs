using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTVideoModel : ModelBase
    {
        private string _kind;
        private string _etag;     
        private string _videoId;
        private YTVideoContentDetails _contentDetails;

        public YTVideoContentDetails ContentDetails
        {
            get { return _contentDetails; }
            set { _contentDetails = value; OnPropertyChanged("ContentDetails"); }
        }

        public string VideoId
        {
            get { return _videoId; }
            set { _videoId = value; OnPropertyChanged("VideoId"); }
        }   

        public string ETag
        {
            get { return _etag; }
            set { _etag = value; OnPropertyChanged("ETag"); }
        }

        public string Kind
        {
            get { return _kind; }
            set { _kind = value; OnPropertyChanged("Kind"); }
        }

    }
}
