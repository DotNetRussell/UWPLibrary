using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTChannelContentDetails : ModelBase, YTIContentDetails
    {
        private YTRelatedPlaylistsModel _relatedPlaylists;
        private string _googlePlusUserId;

        public string GooglePlusUserId
        {
            get { return _googlePlusUserId; }
            set { _googlePlusUserId = value; OnPropertyChanged("GooglePlusUserId"); }
        }

        public YTRelatedPlaylistsModel RelatedPlaylists
        {
            get { return _relatedPlaylists; }
            set { _relatedPlaylists = value; OnPropertyChanged("RelatedPlaylists"); }
        }
    }
}
