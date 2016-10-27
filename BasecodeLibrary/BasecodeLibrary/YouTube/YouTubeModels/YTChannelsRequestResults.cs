using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTChannelsRequestResults : ModelBase
    {
        private string _kind;
        private string _etag;
        private string _nextPageToken;
        private string _previousPageToken;
        private YTPageInfoModel _pageInfo;
        private IEnumerable<YTChannelModel> _items;

        public IEnumerable<YTChannelModel> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        public YTPageInfoModel PageInfo
        {
            get { return _pageInfo; }
            set { _pageInfo = value; OnPropertyChanged("PageInfo"); }
        }


        public string PreviousPageToken
        {
            get { return _previousPageToken; }
            set { _previousPageToken = value; OnPropertyChanged("PreviousPageToken"); }
        }


        public string NextPageToken
        {
            get { return _nextPageToken; }
            set { _nextPageToken = value; OnPropertyChanged("NextPageToken"); }
        }


        public string Etag
        {
            get { return _etag; }
            set { _etag = value; OnPropertyChanged("Etag"); }
        }


        public string Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }
    }
}
