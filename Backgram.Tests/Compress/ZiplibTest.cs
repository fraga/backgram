using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgram.Compress;

namespace Backgram.Tests.Compress
{
    [TestClass]
    public class ZiplibTest
    {
        [TestMethod]
        public void TestConstructorNotNull()
        {
            Ziplib zipLib = new Ziplib();
            Assert.IsNotNull(zipLib);
        }
    }
}
