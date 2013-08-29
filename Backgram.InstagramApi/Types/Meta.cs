using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgram.InstagramApi.Types
{
    public class Meta
    {
        public static const string HTTP_META_ERROR = "400";
        public static const string HTTP_OK = "200";

        public string code { get; set; }
    }
}
