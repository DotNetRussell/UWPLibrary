using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTPlaylistsRequestResults : ModelBase
    {
        private string _kind;
        private string _etag;
        private YTPageInfoModel _pageInfo;
        private List<YTItemModel> _items;

        public List<YTItemModel> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        public YTPageInfoModel PageInfo
        {
            get { return _pageInfo; }
            set { _pageInfo = value; OnPropertyChanged("PageInfo"); }
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
