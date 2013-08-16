using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi
{
    public class UsersSelfFeedEndpoint: BaseInstagramEndpoint
    {
        public string Endpoint { get { return String.Format("https://api.instagram.com/v1/users/self/feed?access_token={0}", InstagramData != null ? InstagramData.AccessToken : string.Empty); } }

        public override string Get()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(new Uri(Endpoint)).Result;

                return result.Content.ReadAsStringAsync().Result;
            }

        }
    }
}
