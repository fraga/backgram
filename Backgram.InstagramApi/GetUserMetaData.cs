﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Backgram.InstagramApi
{
    [Export(typeof(IHttpRestfulEndpoint))]
    [ExportMetadata("version", "1.0")]
    [ExportMetadata("endpoint", "users/userId")]
    public class GetUserMetaData : IHttpRestfulEndpoint
    {
        public string Get(string endpoint)
        {
            throw new NotImplementedException();
        }

        public string Post(string endpoint)
        {
            throw new NotImplementedException();
        }

        public string Delete(string endpoint)
        {
            throw new NotImplementedException();
        }
    }
}
