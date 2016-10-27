using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasecodeLibrary.Interfaces
{
    /// <summary>
    /// Interface that defines extra filterable logic. If implemented on a filterable item data object, the 
    /// IsFilterMatch method will be invoked when filtering items
    /// </summary>
    public interface IFilterableItem
    {
        bool IsFilterMatch(string filterText);
    }
}
