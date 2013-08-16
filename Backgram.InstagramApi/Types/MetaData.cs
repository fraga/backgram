using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi.Types
{
    /// <summary>
    /// Holds instagram result medatada
    /// </summary>
    public class MetaData
    {
        /// <summary>
        /// Constructor must initialize inner classes
        /// </summary>
        public MetaData()
        {
            pagination = new Pagination();
        }
        /// <summary>
        /// <seealso cref="Pagination"/>
        /// </summary>
        public Pagination pagination { get; set; }
    }


}
