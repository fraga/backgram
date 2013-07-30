using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Backgram.InstagramApi
{
    [Export(typeof(IHttpRestfulEndpoint))]
    [ExportMetadata("version", "1.0")]
    [ExportMetadata("baseuri", "https://api.instagram.com/v1")]
    [ExportMetadata("endpoint", "users/userId")]
    public class GetUserMetaDataV1 : IHttpRestfulEndpoint
    {
        public string Get()
        {
            throw new NotImplementedException();
        }

        public string Post()
        {
            throw new NotSupportedException("User metadata does not allows post actions");
        }

        public string Delete()
        {
            throw new NotSupportedException("User metadata does not allows delete actions");
        }

        public string EndPoint
        {
            get
            {
                return "https://api.instagram.com/v1/users/userid";
            }
            set
            {
                
            }
        }
    }
}
