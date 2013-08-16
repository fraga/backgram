using Backgram.Core.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi
{
    [Export(typeof(IInstagramEndpoint))]
    [ExportMetadata("Name", "AuthAuthorize")]
    [ExportMetadata("Version", "1.0")]
    public class OAuthAuthorizeCode: BaseInstagramEndpoint
    {
        public override string EndPoint
        {
            get
            {
                return "https://api.instagram.com/oauth/access_token";
            }
        }

        public override string Post()
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("client_id", InstagramData.ClientId),
                    new KeyValuePair<string, string>("client_secret", InstagramData.ClientSecret),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("redirect_uri", InstagramData.RedirectURI),
                    new KeyValuePair<string, string>("code", InstagramData.Code),

                });

                var result = client.PostAsync(new Uri(EndPoint), content).Result;

                return result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
