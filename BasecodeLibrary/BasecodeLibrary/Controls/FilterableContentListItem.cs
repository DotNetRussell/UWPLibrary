using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace BasecodeLibrary.Controls
{
    /// <summary>
    /// The root list item for FilterableContentList
    /// </summary>
    [ContentProperty(Name = "DataObject")]
    public class FilterableContentListItem 
    {
        /// <summary>
        /// Content Title 
        /// </summary>
        public string ContentTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Short description of content
        /// </summary>
        public string ContentShortDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Image url or uri
        /// </summary>
        public Uri ImageURI
        {
            get;
            set;
        }
        
        /// <summary>
        /// The object being represented
        /// </summary>
        public Object DataObject
        {
            get;
            set;
        }
        
        /// <summary>
        /// Dimensions for the image
        /// </summary>
        public Point ImageDimensions
        {
            get;
            set;
        }

        /// <summary>
        /// Returns true if the item has details
        /// </summary>
        public bool HasDetails
        {
            get { return !String.IsNullOrEmpty(Details); }
        }
        
        /// <summary>
        /// Details about the object
        /// </summary>
        public string Details
        {
            get;
            set;
        }

    }
}
