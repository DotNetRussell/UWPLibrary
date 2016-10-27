using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseCodeLibrary.YouTube.YTEnums;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTThumbnailModel : ModelBase
    {
        private string _Url;
        private string _width;
        private string _height;
        private ThumbnailSizes _thumbnailSize;

        public ThumbnailSizes ThumbnailSize
        {
            get { return _thumbnailSize; }
            set { _thumbnailSize = value; OnPropertyChanged("ThumbnailSize"); }
        }

        public string Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged("Height"); }
        }

        public string Width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged("Width"); }
        }

        public string Url
        {
            get { return _Url; }
            set { _Url = value; OnPropertyChanged("Url"); }
        }

    }
}
