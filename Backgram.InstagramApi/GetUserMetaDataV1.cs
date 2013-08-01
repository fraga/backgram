﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Net.Http;
using Backgram.Core.Api;

namespace Backgram.InstagramApi
{
    [Export(typeof(IRestfulEndpoint))]
    [ExportMetadata("Version", "1.0")]
    public class GetUserMetaDataV1 : IRestfulEndpoint
    {
        public string AccessToken { get; set; }

        public string Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri endPointUri = new Uri(EndPoint);
                var result = httpClient.GetAsync(new Uri(endPointUri, String.Format("?access_token={0}", AccessToken))).Result;

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public string Post()
        {
            throw new NotSupportedException("User metadata does not allows post actions");
        }

        public string Delete()
        {
            throw new NotSupportedException("User metadata does not allows delete actions");
        }

        public string Put()
        {
            throw new NotSupportedException("User metadata does not allows put actions");
        }

        public string EndPoint
        {
            get
            {
                return "https://api.instagram.com/v1/users/self";
            }
        }


    }
}
