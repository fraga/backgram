using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Backgram.InstagramApi;

namespace Backgram.Core
{
    public class Instagram
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectURI { get; set; }
        public string ResponseType { get; set; }

        [ImportMany]
        public IEnumerable<Lazy<IHttpRestfulEndpoint>> InstagramEndpoints;
    }
}
