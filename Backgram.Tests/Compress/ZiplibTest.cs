using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgram.Compress;

namespace Backgram.Tests.Compress
{
    [TestClass]
    public class ZiplibTest
    {
        private TestContext _testContext;

        public ZiplibTest(TestContext context)
        {
            _testContext = context;
        }

        [TestMethod]
        public void TestConstructorNotNull()
        {
            Ziplib zipLib = new Ziplib();
            Assert.IsNotNull(zipLib);
        }
    }
}
