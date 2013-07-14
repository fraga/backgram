using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgram.Compress;
using System.IO;
using System.Text;

namespace Backgram.Tests.Compress
{
    [TestClass]
    public class ZiplibTest
    {
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestConstructorNotNull()
        {
            Ziplib zipLib = new Ziplib();
            Assert.IsNotNull(zipLib);
        }
    }
}
