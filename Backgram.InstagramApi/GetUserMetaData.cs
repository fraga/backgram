using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Net.Http;
using Backgram.Core.Api;

namespace Backgram.InstagramApi
{
    [Export(typeof(IInstagramEndpoint))]
    [ExportMetadata("Name", "GetUserMetaData")]
    [ExportMetadata("Version", "1.0")]
    public class GetUserMetaData : BaseInstagramEndpoint
    {
        public override string EndPoint { get { return "https://api.instagram.com/v1/users/self"; } }

        public GetUserMetaData(): base()
        {
        }

        public GetUserMetaData(InstagramData instagramData)
        {
            InstagramData = instagramData;
        }

        public override string Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri endPointUri = new Uri(EndPoint);
                var result = httpClient.GetAsync(new Uri(endPointUri, String.Format("?access_token={0}", InstagramData))).Result;

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public override string Post()
        {
            throw new NotSupportedException("User metadata does not allows post actions");
        }

        public override string Delete()
        {
            throw new NotSupportedException("User metadata does not allows delete actions");
        }

        public override string Put()
        {
            throw new NotSupportedException("User metadata does not allows put actions");
        }

    }
}
