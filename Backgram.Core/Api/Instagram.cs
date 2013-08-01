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
            ImportCatalog();
        }

        public void ImportCatalog()
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

        public void Authorize()
        {
            Authorize(InstagramData);
        }

        public void Authorize(InstagramData instagramData)
        {
            if (InstagramEndpoints == null || instagramData == null)
                return;

            var authEndpoint = InstagramEndpoints.ToList().Find(t => t.Metadata.Name == "Auth").Value;

            authEndpoint.InstagramData = instagramData;
            authEndpoint.Post();

        }

    }
}
