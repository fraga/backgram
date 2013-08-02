using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace Backgram.Core.Api
{
    public class Instagram
    {
        public InstagramData InstagramData { get; set; }
        [ImportMany]
        public IEnumerable<Lazy<IInstagramEndpoint, IInstagramEndPointData>> InstagramEndpoints;

        public Instagram()
        {
            ImportAssemblyCatalog();
        }

        public void ImportAssemblyCatalog()
        {
            try
            {
                DirectoryCatalog catalog = new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
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
            return authEndpoint.Post();
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
