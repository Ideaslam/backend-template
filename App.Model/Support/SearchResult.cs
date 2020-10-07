using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Support
{
    /// <summary>
    /// Represents the default search result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchResult<T> : ExecutionResponse<List<T>> where T : class
    {
        /// <summary>
        /// Gets or sets the total count of the items
        /// </summary>
        public int TotalCount { get; set; }
    }
}
