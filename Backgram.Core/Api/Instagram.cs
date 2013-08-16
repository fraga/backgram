using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace Backgram.Core.Api
{
    public class Instagram
    {
        public InstagramData InstagramData { get; set; }
        public string BaseCatalogDirectory { get; set; }
        [ImportMany]
        public IEnumerable<Lazy<IInstagramEndpoint, IInstagramEndPointData>> InstagramEndpoints;

        public void ImportAssemblyCatalog()
        {
            try
            {
                DirectoryCatalog catalog = new DirectoryCatalog(BaseCatalogDirectory);
                CompositionContainer container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (Exception)
            {
            }
        }

        public void AuthorizeRedirect()
        {
            AuthorizeRedirect(InstagramData);
        }

        public string AuthorizeRedirect(InstagramData instagramData)
        {
            if (InstagramEndpoints == null || instagramData == null)
                return string.Empty;

            var authEndpoint = InstagramEndpoints.ToList().Find(t => t.Metadata.Name == "AuthRedirect").Value;

            authEndpoint.InstagramData = instagramData;
            return authEndpoint.Get();

        }

        public string AuthorizeTokenRequest(InstagramData instagramData)
        {
            if (InstagramEndpoints == null || instagramData == null)
                return string.Empty;

            var authEndpoint = InstagramEndpoints.ToList().Find(t => t.Metadata.Name == "AuthAuthorize").Value;

            authEndpoint.InstagramData = instagramData;

            var accessToken = new { access_token = "" };

            var result = JsonConvert.DeserializeAnonymousType(authEndpoint.Post(), accessToken);

            return result.access_token;
        }

        public string GetUserInfo(InstagramData instagramData)
        {
            if (InstagramEndpoints == null || instagramData == null)
                return string.Empty;

            var userMetaData = InstagramEndpoints.ToList().Find(t => t.Metadata.Name == "GetUserMetaData").Value;

            userMetaData.InstagramData = instagramData;
            return userMetaData.Get();
        }

    }
}
