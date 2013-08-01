using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgram.Core.Api;
using System.Net.Http;
using System.ComponentModel.Composition;

namespace Backgram.InstagramApi
{
    [Export(typeof(IRestfulEndpoint))]
    [ExportMetadata("Version", "1.0")]
    public class OAuth20: IRestfulEndpoint
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string AccessToken { get; set; }
        public string EndPoint
        {
            get { return "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=token"; }
        }

        public string Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpContent = httpClient.GetAsync(new Uri(String.Format(EndPoint, ClientId, RedirectUri))).Result;

                return httpContent.Content.ReadAsStringAsync().Result;
            }
        }

        public string Post()
        {
            throw new NotSupportedException();
        }

        public string Delete()
        {
            throw new NotSupportedException();
        }

        public string Put()
        {
            throw new NotSupportedException();
        }

        public HttpContent BuildExplicitAuthHeader()
        {
            return null;
        }
    }
}
