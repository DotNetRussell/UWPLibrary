using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTVideoDetailsContentDetails : ModelBase, YTIContentDetails
    {
        private string _kind;
        private string _etag;
        private string _id;
        private YTSnipperModel _snippet;

        public YTSnipperModel Snippet
        {
            get { return _snippet; }
            set { _snippet = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public string Etag
        {
            get { return _etag; }
            set { _etag = value; OnPropertyChanged("Etag"); }
        }

        public string Kind
        {
            get { return _kind; }
            set { _kind = value; OnPropertyChanged("Kind"); }
        }
    }
}
