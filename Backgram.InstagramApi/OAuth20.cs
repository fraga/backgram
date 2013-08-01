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
    [Export(typeof(IInstagramEndpoint))]
    [ExportMetadata("Name", "Auth")]
    [ExportMetadata("Version", "1.0")]
    public class OAuth20: BaseInstagramEndpoint
    {
        public override string Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpContent = httpClient.GetAsync(new Uri(String.Format("https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=token", ClientId, RedirectURI))).Result;

                return httpContent.Content.ReadAsStringAsync().Result;
            }
        }

        public override string Post()
        {
            throw new NotSupportedException();
        }

        public override string Delete()
        {
            throw new NotSupportedException();
        }

        public override string Put()
        {
            throw new NotSupportedException();
        }

        public HttpContent BuildExplicitAuthHeader()
        {
            return null;
        }
    }
}
