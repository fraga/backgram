using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgram.Compress;
using System.IO;

namespace Backgram.Tests.Compress
{
    [TestClass]
    public class ZiplibTest
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void TestConstructorNotNull()
        {
            Ziplib zipLib = new Ziplib();
            Assert.IsNotNull(zipLib);
        }
    }
}
