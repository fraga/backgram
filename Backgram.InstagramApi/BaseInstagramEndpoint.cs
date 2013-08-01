using Backgram.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi
{
    public abstract class BaseInstagramEndpoint: IInstagramEndpoint, IInstagramData
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectURI { get; set; }
        public string ResponseType { get; set; }
        public string AccessToken { get; set; }
        public string EndPoint { get; set; }

        public virtual string Get()
        {
            throw new NotImplementedException();
        }

        public virtual string Post()
        {
            throw new NotImplementedException();
        }

        public virtual string Delete()
        {
            throw new NotImplementedException();
        }

        public virtual string Put()
        {
            throw new NotImplementedException();
        }

    }
}
