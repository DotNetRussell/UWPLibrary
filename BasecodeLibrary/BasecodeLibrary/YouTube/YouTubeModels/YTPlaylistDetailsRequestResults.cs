using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTPlaylistDetailsRequestResults : ModelBase
    {
        private string _kind;
        private string _etag;
        private YTPageInfoModel _pageInfo;
        private IEnumerable<YTVideoModel> _videos;

        public IEnumerable<YTVideoModel> Videos
        {
            get { return _videos; }
            set { _videos = value; }
        }

        public YTPageInfoModel PageInfo
        {
            get { return _pageInfo; }
            set { _pageInfo = value; }
        }
        
        public string Etag
        {
            get { return _etag; }
            set { _etag = value; }
        }

        public string Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

    }
}
