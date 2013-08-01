using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.Core.Api
{
    public interface IInstagramData
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string RedirectURI { get; set; }
        string ResponseType { get; set; }
        string AccessToken { get; set; }
        string EndPoint { get; }
    }
}
