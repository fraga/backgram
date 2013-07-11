using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;


namespace Backgram.Compress
{
    public class Ziplib
    {
        private string _directory;

        public Ziplib()
        {
        }

        public Ziplib(string dir)
        {
            this._directory = dir;
        }

        public void Compress()
        {
            throw new NotImplementedException();
        }
    }
}
