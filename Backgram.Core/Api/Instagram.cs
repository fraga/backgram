using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Backgram.Core.Api
{
    public class Instagram
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectURI { get; set; }
        public string ResponseType { get; set; }

        [ImportMany]
        public IEnumerable<Lazy<IInstagramRestfulEndpoint>> InstagramEndpoints;
        [ImportMany]
        public IEnumerable<Lazy<IInstagramAuthRestfulEndpoint>> InstagramAuthEndpoints;

        public void Authorize()
        {
            Authorize(ClientId, ClientSecret, RedirectURI, ResponseType);
        }

        public void Authorize(string clientId, string clientSecret, string redirectUri, string responseType)
        {
            if (InstagramEndpoints == null)
                return;

        }

    }
}
