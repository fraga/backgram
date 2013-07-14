using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;



namespace Backgram.Compress
{
    public class Ziplib
    {
        private string _dirToCompress;

        public Ziplib()
        {
        }

        public Ziplib(string dirToCompress)
        {
            this._dirToCompress = dirToCompress;
        }

        public void Compress()
        {
            throw new NotImplementedException();
        }
    }
}
