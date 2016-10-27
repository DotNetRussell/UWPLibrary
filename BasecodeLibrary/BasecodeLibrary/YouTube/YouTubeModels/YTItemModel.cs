using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTItemModel : ModelBase
    {
        private string _kind;
        private string _etag;
        private string _Id;
        private YTIContentDetails _contentDetails;

        public YTIContentDetails ContentDetails
        {
            get { return _contentDetails; }
            set { _contentDetails = value; OnPropertyChanged("ContentDetails"); }
        }

        public string Kind
        {
            get { return _kind; }
            set { _kind = value; OnPropertyChanged("Kind"); }
        }
               
        public string ETag
        {
            get { return _etag; }
            set { _etag = value; OnPropertyChanged("ETag"); }
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged("Id"); }
        }
    }
}
