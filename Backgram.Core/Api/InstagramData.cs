using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.Core.Api
{
    public class InstagramData
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectURI { get; set; }
        public string ResponseType { get; set; }
        public string AccessToken { get; set; }
    }
}
