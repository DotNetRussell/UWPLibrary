using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTSnipperModel : ModelBase
    {
        private string _publishedAt;
        private string _channelId;
        private string _title;
        private string _description;
        private string _channelTitle;
        private int _categoryId;
        private string _liveBroadcastContent;
        private List<YTThumbnailModel> _thumbnails;

        public string LiveBroadcastContent
        {
            get { return _liveBroadcastContent; }
            set { _liveBroadcastContent = value; OnPropertyChanged("LiveBroadcastContent"); }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; OnPropertyChanged("CategoryId"); }
        }

        public string ChannelTitle
        {
            get { return _channelTitle; }
            set { _channelTitle = value; OnPropertyChanged("ChannelTitle"); }
        }

        public List<YTThumbnailModel> Thumbnails
        {
            get { return _thumbnails; }
            set { _thumbnails = value; OnPropertyChanged("Thumbnails"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }

        public string ChannelId
        {
            get { return _channelId; }
            set { _channelId = value; OnPropertyChanged("ChannelId"); }
        }

        public string PublishedAt
        {
            get { return _publishedAt; }
            set { _publishedAt = value; OnPropertyChanged("PublishedAt"); }
        }
    }
}
