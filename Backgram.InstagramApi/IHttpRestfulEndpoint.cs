using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi
{
    public interface IHttpRestfulEndpoint
    {
        string Get(string endpoint);
        string Post(string endpoint);
        string Delete(string endpoint);
    }
}
