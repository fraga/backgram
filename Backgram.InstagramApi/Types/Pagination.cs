using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi.Types
{
    /// <summary>
    /// Pagination holds instagram paging information
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// The next url that you can get, will be the next page
        /// </summary>
        public string next_url { get; set; }
    }
}
