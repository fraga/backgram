using Backgram.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi
{
    public abstract class BaseInstagramEndpoint: IInstagramEndpoint
    {
        public InstagramData InstagramData { get; set; }

        public BaseInstagramEndpoint()
        {
            InstagramData = new InstagramData();
        }

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

        public virtual string EndPoint
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
