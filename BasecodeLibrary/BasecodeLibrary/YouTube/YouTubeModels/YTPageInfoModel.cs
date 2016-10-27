using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeLibrary.YouTube.YouTubeModels
{
    public class YTPageInfoModel : ModelBase
    {
        private string _totalResults;
        private string _resultsPerPage;

        public string TotalResults
        {
            get { return _totalResults; }
            set { _totalResults = value; OnPropertyChanged("PageInfo"); }
        }

        public string ResultsPerPage
        {
            get { return _resultsPerPage; }
            set { _resultsPerPage = value; OnPropertyChanged("ResultsPerPage"); }
        }
    }
}
