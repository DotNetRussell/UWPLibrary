using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTRelatedPlaylistsModel : ModelBase
    {
        private string _uploads;

        public string Uploads
        {
            get { return _uploads; }
            set { _uploads = value; OnPropertyChanged("Uploads"); }
        }
    }
}
