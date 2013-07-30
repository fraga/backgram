using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi
{
    public interface IHttpRestfulEndpoint
    {
        string EndPoint { get; }
        string Get();
        string Post();
        string Delete();
        string Put();
    }
}
